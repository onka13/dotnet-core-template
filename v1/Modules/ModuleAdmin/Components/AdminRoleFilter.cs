using CoreCommon.Data.Domain.Attributes;
using CoreCommon.Data.Domain.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ModuleAdmin.IRepositories;
using System;
using System.Linq;

namespace ModuleAdmin.Components
{
    public class AdminRoleFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var badResult = new BadRequestObjectResult(ServiceResult.Instance.ErrorResult(ServiceResultCode.NoPermission));

            var userData = AdminHelper.GetDataFromToken(AdminHelper.GetTokenFromHeader(context.HttpContext.Request));
            if (userData == null) return;

            // super admin
            if (userData.IsSuper) return;

            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            RoleActionAttribute roleAction = AdminHelper.GetControllerRoleAction(controllerActionDescriptor.ControllerTypeInfo);
            if (roleAction == null) return;

            var methodRoleAttribute = controllerActionDescriptor.MethodInfo.GetCustomAttributes(false).OfType<RoleActionAttribute>().FirstOrDefault();
            if (methodRoleAttribute != null)
            {
                roleAction.ActionKey = methodRoleAttribute.ActionKey;
                if (!string.IsNullOrEmpty(methodRoleAttribute.ModuleKey))
                    roleAction.ModuleKey = methodRoleAttribute.ModuleKey;
                if (!string.IsNullOrEmpty(methodRoleAttribute.PageKey))
                    roleAction.PageKey = methodRoleAttribute.PageKey;
            }

            if (string.IsNullOrWhiteSpace(roleAction.ActionKey)) return;

            if (roleAction.ActionKey == "super")
            {
                context.Result = badResult;
                return;
            }

            if (roleAction.ActionKey == "admin")
            {
                context.Result = badResult;
                return;
            }

            var userRepository = (IAdminUserRepository)context.HttpContext.RequestServices.GetService(typeof(IAdminUserRepository));
            bool hasAccess = userRepository.HasAccess(userData.UserId, roleAction.ModuleKey, roleAction.PageKey, roleAction.ActionKey);
            if (!hasAccess)
            {
                context.Result = badResult;
            }
        }
    }
}
