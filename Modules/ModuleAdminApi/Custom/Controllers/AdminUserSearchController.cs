
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
    [RoleAction("AdminApi","AdminUser", null)]
    [Route("api/AdminUserSearch")]
    [ApiController]
    public partial class AdminUserSearchController
    {
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
            return Create0(model);
        }
        [RoleAction("edit")]
        [HttpPost("update")]
        public ActionResult Update(AdminUserEntityModel model)
        {
            return Update0(model);
        }
    }
}
