using DotNetCommon.Data.Domain.Enums;
using DotNetCommon.Data.Domain.Models;
using DotNetCommon.Infrastructure.Helpers;
using DotNetTemplate.Business.Service.User;
using DotNetTemplate.Domain.Business;
using DotNetTemplate.Domain.User;
using DotNetTemplate.Domain.User.Models;
using Microsoft.Extensions.Options;

namespace DotNetTemplate.Business.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    /// <summary>
    /// User Configuration settings in appsettings
    /// </summary>
    private readonly UserConfig userConfig;

    public UserService(IUserRepository userRepository, IOptions<UserConfig> userConfig)
    {
        this.userRepository = userRepository;
        this.userConfig = userConfig.Value;
    }

    /// <summary>
    /// logins a user with email & pass
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<AuthResponse> Login(string email, string password)
    {
        var user = await userRepository.GetByEmail(email);
        if (user == null || user.Status != Status.Active)
        {
            throw new AppException(ResponseCodes.UserInvalidLogin);
        }

        if (user.LockoutEndDateUtc.HasValue && user.LockoutEndDateUtc > DateTime.UtcNow)
        {
            throw new AppException(ResponseCodes.UserLockedout);
        }

        if (!AuthHelper.ValidateHash(password, userConfig.UserPasswordSalt, user.PasswordHash))
        {
            int responseCode = ResponseCodes.UserInvalidLogin;
            if (user.AccessFailedCount % 5 == 4)
            {
                user.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(10);
                responseCode = ResponseCodes.UserLockedout;
            }

            user.AccessFailedCount++;
            await userRepository.UpdateOnly(user, x => x.AccessFailedCount);
            throw new AppException(responseCode);
        }

        user.LastLoginDate = DateTime.UtcNow;
        user.AccessFailedCount = 0;
        await userRepository.UpdateOnly(user, x => x.AccessFailedCount, x => x.LastLoginDate);

        var tokenData = new UserTokenData
        {
            Id = user.Id,
            Email = email,
        };

        var expiresIn = TimeSpan.FromDays(1);
        string token = AuthHelper.EncryptTicket(tokenData.Email, userConfig.UserTokenSecret, expiresIn, tokenData);

        return new AuthResponse
        {
            AccessToken = token,
            ExpiresIn = (int)expiresIn.TotalMinutes,
            TokenType = "Bearer",
            Uid = user.Id,
        };
    }

    /// <summary>
    /// Registers a user
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="password">Password</param>
    /// <param name="name">Name of the user</param>
    /// <returns></returns>
    public async Task Register(string email, string password, string name)
    {
        var user = await userRepository.GetByEmail(email);
        if (user != null)
        {
            if (!user.IsVerifiedByEmail)
            {
                throw new AppException(ResponseCodes.EmailShouldVerify);
            }

            throw new AppException(ResponseCodes.RegisterEmailAlreadyExist);
        }

        user = new()
        {
            Email = email,
            Name = name,
            PasswordHash = AuthHelper.HashPassword(password, userConfig.UserPasswordSalt),
            Status = Status.Active,
            IsVerified = false,
            AccessFailedCount = 0,
            LockoutEndDateUtc = null,
        };
        await userRepository.Add(user);

        // send email/phone verification
    }
}
