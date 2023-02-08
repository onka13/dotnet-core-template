using CoreCommon.Data.Domain.Business;
using CoreCommon.ModuleBase.Components;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.IServices;
using ModuleAdmin.Models;
using ModuleAdmin.ApiBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleAdmin.ApiBase.Controllers
{
    [Route("AdminApi/public")]
    public class AdminPublicController : CommonBaseController
    {
        public IAdminUserBusinessLogic UserBusinessLogic { get; set; }
        public IAdminRoleDefinitionBusinessLogic RoleDefinitionBusinessLogic { get; set; }
        public IAdminUserRoleMapBusinessLogic RoleMapBusinessLogic { get; set; }

        [Route("login")]
        [HttpPost]
        public ServiceResult<AdminLoginResponseModel> Login(LoginRequestModel model)
        {
            var response = UserBusinessLogic.Login(model.Email, model.Password);

            if (response.Success && !response.Value.IsSuper)
            {
                var userRoles = RoleMapBusinessLogic.FindBy(x => x.UserId == response.Value.UserId).Value.Select(x => x.RoleId).ToList();
                response.Value.Roles = RoleDefinitionBusinessLogic.FindBy(x => userRoles.Contains(x.RoleId)).Value.ToList();
            }

            return response;
        }

    }
}
