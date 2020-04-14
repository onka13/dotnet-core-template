
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.Services;
using ModuleAdminApi.Generated.RequestEntities;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.IServices;
using CoreCommon.Data.Domain.Business;using CoreCommon.Data.Domain.Models;using CoreCommon.Data.Domain.Attributes;

namespace ModuleAdminApi.Generated.Controllers
{
    [RoleAction("AdminApi","AdminRole", null)]
    [Route("admin/AdminRoleSearch")]
    [ApiController]
    public partial class AdminRoleSearchController
    {
        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<AdminRoleSearchRequest> model)
        {
            return Search0(model);
        }
        [RoleAction("get")]
        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            return Get0(id);
        }
        [RoleAction("get")]
        [HttpPost("gets")]
        public IActionResult Gets(List<int> ids)
        {
            var response = AdminRoleBusinessLogic.FindBy(x => ids.Contains(x.Id));
            return SuccessResponse(response.Value.Select(x => new { x.Id, x.Name }));
        }
        [RoleAction("new")]
        [HttpPost("new")]
        public ActionResult Create(AdminRoleEntityModel model)
        {
            return Create0(model);
        }
        [RoleAction("edit")]
        [HttpPost("update")]
        public ActionResult Update(AdminRoleEntityModel model)
        {
            return Update0(model);
        }
    }
}
