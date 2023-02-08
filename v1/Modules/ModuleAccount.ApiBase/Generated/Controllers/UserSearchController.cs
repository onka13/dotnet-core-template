/*
Auto generated file. Do not edit!
*/
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Models;
using CoreCommon.Data.Domain.Attributes;
using ModuleAccount.Services;
using ModuleAccount.ApiBase.Generated.RequestEntities;
using ModuleAccount.Generated.Entities;
using ModuleAccount.IServices;

namespace ModuleAccount.ApiBase.Generated.Controllers
{
    public partial class UserSearchController : AccountApiBaseController
    {
        public IUserBusinessLogic UserBusinessLogic { get; set; }

        protected ActionResult Search0(ApiRequestListModel<UserSearchRequest> model)
        {
            int skip = (model.Pagination.Page - 1) * Math.Min(model.Pagination.PerPage, 200);
            long _total;
            var response = UserBusinessLogic.Search(model.Filter.Id,model.Filter.Name,model.Filter.Email,model.Filter.EmailConfirmed,model.Filter.Status, model.Sort?.Field, model.Sort?.Order == "ASC", skip, model.Pagination.PerPage, out _total);
            return Json(ServiceListResult<object>.Instance.SuccessResult(response.Value, _total));
        }
        protected ActionResult Get0(int id)
        {
            var response = UserBusinessLogic.GetBy(x => x.Id == id);
            return Json(response);
        }
        protected ActionResult Create0(UserEntityModel model)
        {
            //entity.CreatedAt = DateTime.Now;
            var responseInsert = UserBusinessLogic.Add(model.ToEntity());
            return Json(responseInsert);
        }
        protected ActionResult Update0(UserEntityModel model)
        {
            //entity.UpdatedAt = DateTime.Now;
            var responseEdit = UserBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult UpdateOnly0(UserEntityModel model)
        {
            var responseEdit = UserBusinessLogic.EditOnly(model.ToEntity(), x => x.Name, x => x.Email, x => x.EmailConfirmed, x => x.Status);
            return Json(responseEdit);
        }
        protected ActionResult Delete0(int id)
        {
            var response = UserBusinessLogic.DeleteBy(x => x.Id == id);
            return Json(response);
        }
    }
}
