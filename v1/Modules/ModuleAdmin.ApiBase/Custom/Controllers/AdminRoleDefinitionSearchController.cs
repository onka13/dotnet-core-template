
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.Services;
using ModuleAdmin.ApiBase.Generated.RequestEntities;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.IServices;
using CoreCommon.Data.Domain.Business;using CoreCommon.Data.Domain.Models;using CoreCommon.Data.Domain.Attributes;

namespace ModuleAdmin.ApiBase.Generated.Controllers
{
    [RoleAction("AdminApi","AdminRoleDefinition", null)]
    [Route("AdminApi/AdminRoleDefinitionSearch")]
    [ApiController]
    public partial class AdminRoleDefinitionSearchController
    {
        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<AdminRoleDefinitionSearchRequest> model)
        {
            return Search0(model);
        }
    }
}
