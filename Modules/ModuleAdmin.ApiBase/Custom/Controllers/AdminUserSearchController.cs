
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.Services;
using ModuleAdmin.ApiBase.Generated.RequestEntities;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.IServices;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Models;
using CoreCommon.Data.Domain.Attributes;
using ModuleAdmin.ApiBase.Models;

namespace ModuleAdmin.ApiBase.Generated.Controllers
{
    [RoleAction("AdminApi", "AdminUser", null)]
    [Route("AdminApi/AdminUserSearch")]
    [ApiController]
    public partial class AdminUserSearchController
    {
        public IAdminUserRoleMapBusinessLogic UserRoleMapBusinessLogic { get; set; }

        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<AdminUserSearchRequest> model)
        {
            return Search0(model);
        }
        [RoleAction("get")]
        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            return Get0(id);
        }
        /*[RoleAction("get")]
        [HttpPost("gets")]
        public IActionResult Gets(List<int> ids)
        {
            var response = AdminUserBusinessLogic.FindBy(x => ids.Contains(x.Id));
            // return SuccessResponse(response.Value.Select(x => new { x.Id, x.Name }));
            return Json(response);
        }*/
        [RoleAction("new")]
        [HttpPost("new")]
        public ActionResult Create(AdminUserEntityModel model)
        {
            var response = AdminUserBusinessLogic.Upsert(model.ToEntity());
            return Json(response);
        }
        [RoleAction("edit")]
        [HttpPost("update")]
        public ActionResult Update(AdminUserEntityModel model)
        {
            var response = AdminUserBusinessLogic.Upsert(model.ToEntity());
            return Json(response);
        }

        [RoleAction("get")]
        [HttpGet("getRoles/{userId}")]
        public IActionResult GetRoles(int userId)
        {
            var response = UserRoleMapBusinessLogic.ListUserRoles(userId);
            return SuccessResponse(new
            {
                role = response.Value
            });
        }

        [RoleAction("assignRole")]
        [HttpPost("assignRole")]
        public IActionResult AssignRole(UserRoleAssignRequest model)
        {
            var response = UserRoleMapBusinessLogic.SaveUserRoles(model.UserId, model.Roles ?? new List<int>());
            return Json(response);
        }
    }
}
