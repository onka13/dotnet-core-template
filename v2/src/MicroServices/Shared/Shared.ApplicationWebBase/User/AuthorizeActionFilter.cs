using System.Security.Claims;
using DotNetCommon.Data.Domain.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Business;
using Shared.Domain.User;

namespace Shared.ApplicationWebBase.User;

/// <summary>
/// Authorizes the user.
/// </summary>
public class AuthorizeActionFilter : IAuthorizationFilter
{
    public AuthorizeActionFilter()
    {
    }

    /// <summary>
    /// Validates jwt token
    /// </summary>
    /// <param name="context"></param>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authManager = context.HttpContext.RequestServices.GetRequiredService<UserAuthManager>();

        var tokenData = authManager.Validate(out bool isExpired);
        if (tokenData != null && !isExpired)
        {
            context.HttpContext.User = new ClaimsPrincipal(new UserIdentity(tokenData));
            return;
        }

        context.Result = new BadRequestObjectResult(ServiceResult.Instance.ErrorResult(SharedResponseCodes.UserInvalidToken));
    }
}
