
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
    [RoleAction("AdminApi","AdminUserRoleMap", null)]
    [Route("api/AdminUserRoleMapSearch")]
    [ApiController]
    public partial class AdminUserRoleMapSearchController
    {
        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<AdminUserRoleMapSearchRequest> model)
        {
            return Search0(model);
        }
        [RoleAction("new")]
        [HttpPost("new")]
        public ActionResult Create(AdminUserRoleMapEntityModel model)
        {
            return Create0(model);
        }
        [RoleAction("delete")]
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Delete0(id);
        }
    }
}
