using CoreCommon.Data.Domain.Business;
using CoreCommon.Infra.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using ModuleAccount.IServices;
using ModuleAccount.Models;
using System.Security.Claims;

namespace ApiModuleAccount.Components.Attributes
{
    /// <summary>
    /// Authorizes the user. 
    /// </summary>
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        public IUserBusinessLogic UserBusinessLogic { get; set; }

        private readonly IOptions<UserConfig> _userConfig;

        public AuthorizeActionFilter(IOptions<UserConfig> userConfig)
        {
            _userConfig = userConfig;
        }

        /// <summary>
        /// Validates jwt token
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Cookies.TryGetValue("token", out string token);
            if (!string.IsNullOrEmpty(token))
            {
                var userBusinessLogic = (IUserBusinessLogic)context.HttpContext.RequestServices.GetService(typeof(IUserBusinessLogic));

                //var userData = UserBusinessLogic.ValidateToken(token, out bool isExpired);
                var userData = AuthHelper.ValidateToken<UserTokenData>(token, _userConfig.Value.UserTokenSecret, out bool isExpired);
                if (userData != null && !isExpired)
                {
                    context.HttpContext.User = new ClaimsPrincipal(new CoreIdentity(userData));
                    return;
                }
            }

            var isAjax = context.HttpContext.Request.Headers.ContainsKey("X-Requested-With") && context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                context.Result = new BadRequestObjectResult(ServiceResult.Instance.ErrorResult(ServiceResultCode.NoPermission));
            }
            else
            {
                //context.Result = new UnauthorizedResult();
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
