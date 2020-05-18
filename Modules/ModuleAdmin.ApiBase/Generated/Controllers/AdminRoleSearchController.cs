
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
    public partial class AdminRoleSearchController : AdminApiBaseController
    {
        public IAdminRoleBusinessLogic AdminRoleBusinessLogic { get; set; }

        protected ActionResult Search0(ApiRequestListModel<AdminRoleSearchRequest> model)
        {
            int skip = (model.Pagination.Page - 1) * Math.Min(model.Pagination.PerPage, 200);
            long _total;
            var response = AdminRoleBusinessLogic.Search(model.Filter.Name, model.Sort?.Field, model.Sort?.Order == "ASC", skip, model.Pagination.PerPage, out _total);
            return Json(ServiceListResult<object>.Instance.SuccessResult(response.Value, _total));
        }
        protected ActionResult Get0(int id)
        {
            var response = AdminRoleBusinessLogic.GetBy(x => x.Id == id);
            return Json(response);
        }
        protected ActionResult Create0(AdminRoleEntityModel model)
        {
            //entity.CreatedAt = DateTime.Now;
            var responseInsert = AdminRoleBusinessLogic.Add(model.ToEntity());
            return Json(responseInsert);
        }
        protected ActionResult Update0(AdminRoleEntityModel model)
        {
            //entity.UpdatedAt = DateTime.Now;
            var responseEdit = AdminRoleBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult Delete0(int id)
        {
            var response = AdminRoleBusinessLogic.DeleteBy(x => x.Id == id);
            return Json(response);
        }
    }
}
