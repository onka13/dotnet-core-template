﻿/*
Auto generated file. Do not edit!
*/
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Models;
using CoreCommon.Data.Domain.Attributes;
using ModuleAdmin.Services;
using ModuleAdmin.ApiBase.Generated.RequestEntities;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.IServices;

namespace ModuleAdmin.ApiBase.Generated.Controllers
{
    public partial class AdminUserSearchController : AdminApiBaseController
    {
        public IAdminUserBusinessLogic AdminUserBusinessLogic { get; set; }

        protected ActionResult Search0(ApiRequestListModel<AdminUserSearchRequest> model)
        {
            int skip = (model.Pagination.Page - 1) * Math.Min(model.Pagination.PerPage, 200);
            long _total;
            var response = AdminUserBusinessLogic.Search(model.Filter.Name,model.Filter.Email,model.Filter.Status,model.Filter.Id, model.Sort?.Field, model.Sort?.Order == "ASC", skip, model.Pagination.PerPage, out _total);
            return Json(ServiceListResult<object>.Instance.SuccessResult(response.Value, _total));
        }
        protected ActionResult Get0(int id)
        {
            var response = AdminUserBusinessLogic.GetBy(x => x.Id == id);
            return Json(response);
        }
        protected ActionResult Create0(AdminUserEntityModel model)
        {
            //entity.CreatedAt = DateTime.Now;
            var responseInsert = AdminUserBusinessLogic.Add(model.ToEntity());
            return Json(responseInsert);
        }
        protected ActionResult Update0(AdminUserEntityModel model)
        {
            //entity.UpdatedAt = DateTime.Now;
            var responseEdit = AdminUserBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult UpdateOnly0(AdminUserEntityModel model)
        {
            var responseEdit = AdminUserBusinessLogic.EditOnly(model.ToEntity(), x => x.No, x => x.Name, x => x.Email, x => x.Status, x => x.IsSuper);
            return Json(responseEdit);
        }
        protected ActionResult Delete0(int id)
        {
            var response = AdminUserBusinessLogic.DeleteBy(x => x.Id == id);
            return Json(response);
        }
    }
}
