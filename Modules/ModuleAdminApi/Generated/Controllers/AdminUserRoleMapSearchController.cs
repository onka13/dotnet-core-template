
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
    public partial class AdminUserRoleMapSearchController : AdminApiBaseController
    {
        public IAdminUserRoleMapBusinessLogic AdminUserRoleMapBusinessLogic { get; set; }

        protected ActionResult Search0(ApiRequestListModel<AdminUserRoleMapSearchRequest> model)
        {
            int skip = (model.Pagination.Page - 1) * Math.Min(model.Pagination.PerPage, 200);
            long _total;
            var response = AdminUserRoleMapBusinessLogic.Search(model.Filter.UserId,model.Filter.RoleId, model.Sort?.Field, model.Sort?.Order == "ASC", skip, model.Pagination.PerPage, out _total);
            return Json(ServiceListResult<object>.Instance.SuccessResult(response.Value, _total));
        }
        protected ActionResult Get0(int id)
        {
            var response = AdminUserRoleMapBusinessLogic.GetBy(x => x.Id == id);
            return Json(response);
        }
        protected ActionResult Create0(AdminUserRoleMapEntityModel model)
        {
            //entity.CreatedAt = DateTime.Now;
            var responseInsert = AdminUserRoleMapBusinessLogic.Add(model.ToEntity());
            return Json(responseInsert);
        }
        protected ActionResult Update0(AdminUserRoleMapEntityModel model)
        {
            //entity.UpdatedAt = DateTime.Now;
            var responseEdit = AdminUserRoleMapBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult Delete0(int id)
        {
            var response = AdminUserRoleMapBusinessLogic.DeleteBy(x => x.Id == id);
            return Json(response);
        }
    }
}
