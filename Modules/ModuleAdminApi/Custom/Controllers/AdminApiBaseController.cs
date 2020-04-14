
using CoreCommon.Data.Domain.Attributes;
using CoreCommon.Data.Domain.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ModuleAdmin.Components;
using ModuleAdmin.Models;
using ModuleCommonApi.Components;
using System.Linq;

namespace ModuleAdminApi.Generated.Controllers
{
    [TypeFilter(typeof(AdminFilter))]
    [TypeFilter(typeof(AdminRoleFilter))]
    public class AdminApiBaseController : BaseController
    {
        protected AdminTokenData MainTokenData;

        protected string GetTokenFromHeader()
        {
            return GetFromHeader(AdminHelper.TokenName);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ModelState.IsValid)
            {
                string msg = "";
                var methodIgnoreAttribute = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(false).OfType<ModelStateIgnoreAttribute>().FirstOrDefault();
                foreach (var item in context.ModelState.Where(x => x.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid))
                {
                    if (methodIgnoreAttribute != null && methodIgnoreAttribute.Names.Contains(item.Key))
                    {
                        context.ModelState.Remove(item.Key);
                        continue;
                    }
                    msg += "\n" + item.Key;
                    foreach (var err in item.Value.Errors)
                    {
                        msg += "\n" + err.ErrorMessage;
                        if (err.Exception != null) msg += "exception: " + err.Exception.Message;
                    }
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    context.Result = new BadRequestObjectResult(ServiceResult<string>.Instance.ErrorResult(ServiceResultCode.InvalidModel, "Invalid Model" + msg));
                    return;
                }
            }


            MainTokenData = AdminHelper.GetDataFromToken(GetTokenFromHeader());
        }
    }
}
