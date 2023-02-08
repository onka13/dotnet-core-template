using System.Threading.Tasks;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Infra.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModuleAdmin.Models;

namespace ModuleAdmin.Components
{
    public class AdminFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int code = ServiceResultCodeAdmin.LoginUser;
            var authHeader = context.HttpContext.Request.Headers[AdminHelper.TokenName];
            if (authHeader.Count > 0)
            {
                string token = authHeader[0].Trim();
                var userData = AdminHelper.GetDataFromToken(token, out bool isExpired);
                if (userData != null && !isExpired)
                    return;

                if (isExpired)
                    code = ServiceResultCodeAdmin.RefreshToken;
            }
            context.Result = new BadRequestObjectResult(ServiceResult.Instance.ErrorResult(code));

        }
    }
}
