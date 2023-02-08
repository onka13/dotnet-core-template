using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Enums;
using System;
using ModuleAccount.Models;
using CoreCommon.Infra.Helpers;
using Microsoft.Extensions.Options;
using ModuleAccount.Generated.Entities;
using System.Linq;

namespace ModuleAccount.Services
{
    /// <summary>
    /// Contains custom methods for user services
    /// </summary>
    public partial class UserBusinessLogic
    {
        /// <summary>
        /// User Configuration settings in appsettings
        /// </summary>
        public IOptions<UserConfig> UserConfig { get; set; }

        /// <summary>
        /// logins a user with email & pass
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ServiceResult<LoginResponseModel> Login(string email, string password)
        {
            var response = ServiceResult<LoginResponseModel>.Instance.ErrorResult(ResponseCodes.UserInvalidLogin);

            // TODO: validation

            var user = Repository.GetByEmail(email);
            if (user == null || user.Status != Status.Active)
            {
                return response;
            }

            if (user.LockoutEndDateUtc.HasValue && user.LockoutEndDateUtc > DateTime.UtcNow)
            {
                return response;
            }

            if (!AuthHelper.ValidateHash(password, UserConfig.Value.UserPasswordSalt, user.PasswordHash))
            {
                if (user.AccessFailedCount % 5 == 4)
                {
                    user.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(10);
                    response = response.ErrorResult(ResponseCodes.UserLockedout);
                }
                user.AccessFailedCount++;
                EditOnly(user, x => x.AccessFailedCount);
                return response;
            }

            return Login(user.Id, email);
        }

        /// <summary>
        /// Registers a user
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <param name="name">Name of the user</param>
        /// <returns></returns>
        public ServiceResult<LoginResponseModel> RegisterUser(string email, string password, string name)
        {
            var response = ServiceResult<LoginResponseModel>.Instance.ErrorResult(0);

            // TODO: validation

            var user = Repository.GetByEmail(email);
            if (user != null)
            {
                return Login(email, password);    
            }
            else
            {
                user = new UserEntity()
                {
                    Email = email,
                    Name = name,
                    PasswordHash = AuthHelper.HashPassword(password, UserConfig.Value.UserPasswordSalt),
                    Status = Status.Active,
                    EmailConfirmed = false,
                    AccessFailedCount = 0,
                    LockoutEndDateUtc = null                    
                };
                user = Repository.Add(user);
            }

            return Login(user.Id, email);
        }

        /// <summary>
        /// Common method for login and register services.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        private ServiceResult<LoginResponseModel> Login(int id, string email)
        {
            var tokenData = new UserTokenData
            {
                Id = id,
                Email = email
            };

            string token = AuthHelper.CreateToken(UserConfig.Value.UserTokenSecret, 60 * 24, tokenData);

            return ServiceResult<LoginResponseModel>.Instance.SuccessResult(new LoginResponseModel
            {
                Id = id,
                Token = token
            });
        }
        
        /// <summary>
        /// Validates user token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="isExpired"></param>
        /// <returns>returns UserToken data if succeeded</returns>
        public UserTokenData ValidateToken(string token, out bool isExpired)
        {
            return AuthHelper.ValidateToken<UserTokenData>(token, UserConfig.Value.UserTokenSecret, out isExpired);
        }

        /// <summary>
        /// Gets user email address by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserEmail(int userId)
        {
            return Repository.FindBy(x => x.Id == userId).Select(x => x.Email).FirstOrDefault();
        }
    }
}
