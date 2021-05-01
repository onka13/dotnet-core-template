using CoreCommon.Data.Domain.Attributes;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.IServices;
using ModuleAdmin.ApiBase.Generated.Controllers;
using ModuleAdmin.ApiBase.Models;
using ModuleCommon.Business;
using System.Collections.Generic;
using System.Linq;

namespace ModuleAdmin.ApiBase.Controllers
{
    [RoleAction(null, "RoleMap", null)]
    [Route("AdminApi/RoleMap")]
    [ApiController]
    public class RoleMapController : AdminApiBaseController
    {
        public IAdminRoleActionListBusinessLogic RoleActionListBusinessLogic { get; set; }
        public IAdminRoleBusinessLogic RoleBusinessLogic { get; set; }
        public IAdminRoleDefinitionBusinessLogic RoleDefinitionBusinessLogic { get; set; }

        [RoleAction("list")]
        [HttpPost("all")]
        public IActionResult List(ApiRequestListModel<AdminRoleMapListRequest> model)
        {
            var currentRoles = RoleDefinitionBusinessLogic.GetAll().Value;
            var roles = RoleBusinessLogic.GetAll().Value;
            var roleActions = RoleActionListBusinessLogic.GetAll().Value.ToList();
            return SuccessResponse(new { roles, roleActions, currentRoles });
        }

        [RoleAction("save")]
        [HttpPost("save")]
        public IActionResult SaveMap(AdminRoleMapSaveRequest model)
        {
            var response = RoleBusinessLogic.SaveMap(model.Roles);
            response.Code = ServiceResultCode.Updated;
            return Json(response);
        }

        [Route("updateRoleActionList")]
        [HttpPost]
        public IActionResult UpdateRoleActionList()
        {
            var response = RoleActionListBusinessLogic.UpdateRoleActionList(ModuleHelper.FindAllAssemblies(), typeof(Controller));
            return Json(response);
        }
    }
}
