using CoreCommon.Data.Domain.Attributes;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.IServices;
using ModuleAdminApi.Generated.Controllers;
using ModuleAdminApi.Models;
using ModuleCommon.Business;
using System.Collections.Generic;
using System.Linq;

namespace ModuleAdminApi.Controllers
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
            return Json(ServiceListResult<object>.Instance.SuccessResult(new List<object> {
                new { id = 123, roles, roleActions, currentRoles }
            }, 1));
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
        [HttpGet]
        public IActionResult UpdateRoleActionList()
        {
            var response = RoleActionListBusinessLogic.UpdateRoleActionList(ModuleHelper.FindAllAssemblies(), typeof(Controller));
            return Json(response);
        }
    }
}
