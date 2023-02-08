using DotNetCommon.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Shared.Domain.User;

namespace Shared.ApplicationWebBase.User;

public class UserAuthManager
{
    /// <summary>
    /// User Configuration settings in appsettings
    /// </summary>
    private readonly UserConfig userConfig;
    private readonly HttpContext httpContext;

    public UserAuthManager(UserConfig userConfig, IHttpContextAccessor httpContextAccessor)
    {
        this.userConfig = userConfig;
        ArgumentNullException.ThrowIfNull(httpContextAccessor.HttpContext, "HttpContext");
        httpContext = httpContextAccessor.HttpContext;
    }

    public UserTokenData? Validate(out bool isExpired)
    {
        if (!Enum.TryParse(httpContext.Request.Headers["AuthSchema"], out UserAuthSchema userAuthSchema))
        {
            userAuthSchema = UserAuthSchema.Web;
        }

        return Validate(userAuthSchema, out isExpired);
    }

    public UserTokenData? Validate(UserAuthSchema authSchema, out bool isExpired, string? token = null)
    {
        if (!string.IsNullOrWhiteSpace(token))
        {
            switch (authSchema)
            {
                case UserAuthSchema.Web:
                    token = httpContext.Request.Cookies[GetTokenName(authSchema)];
                    break;
                case UserAuthSchema.Mobile:
                    token = httpContext.Request.Headers[GetTokenName(authSchema)];
                    break;
            }
        }

        return ValidateToken(token, out isExpired);
    }

    public UserTokenData? ValidateToken(string? token, out bool isExpired)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            isExpired = false;
            return null;
        }

        if (token.StartsWith("Bearer ", StringComparison.InvariantCultureIgnoreCase))
        {
            token = token.Remove(0, "Bearer ".Length);
        }

        // Call UserMicroService if it's microservice structure
        return AuthHelper.DecryptTicket<UserTokenData>(token, userConfig.UserTokenSecret, out isExpired);
    }

    public string CreateToken(UserTokenData identity, TimeSpan? expiryDuration = null)
    {
        if (expiryDuration == null)
        {
            expiryDuration = TimeSpan.FromMinutes(userConfig.ExpiryDurationInMinutes);
        }

        string token = AuthHelper.EncryptTicket(identity.Id, userConfig.UserTokenSecret, expiryDuration.Value, identity);

        if (identity.AuthSchema == UserAuthSchema.Web)
        {
            httpContext.Response.Cookies.Append(GetTokenName(identity.AuthSchema), token, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.UtcNow.Add(expiryDuration.Value),
                IsEssential = true,
                Domain = userConfig.CookieDomain,
                Path = "/; SameSite=None", // https://stackoverflow.com/a/58817862/5064278
            });
        }

        return token;
    }

    public string GetTokenName(UserAuthSchema authSchema)
    {
        return $"{userConfig.TokenName}_{authSchema}";
    }
}
