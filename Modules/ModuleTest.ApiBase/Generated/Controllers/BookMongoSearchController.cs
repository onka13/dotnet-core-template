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
using ModuleTest.Services;
using ModuleTest.ApiBase.Generated.RequestEntities;
using ModuleTest.Generated.Entities;
using ModuleTest.IServices;

namespace ModuleTest.ApiBase.Generated.Controllers
{
    public partial class BookMongoSearchController : TestApiBaseController
    {
        public IBookMongoBusinessLogic BookMongoBusinessLogic { get; set; }

        protected ActionResult Search0(ApiRequestListModel<BookMongoSearchRequest> model)
        {
            int skip = (model.Pagination.Page - 1) * Math.Min(model.Pagination.PerPage, 200);
            long _total;
            var response = BookMongoBusinessLogic.Search(model.Filter.Id,model.Filter.Name,model.Filter.Price,model.Filter.Category,model.Filter.Author, model.Sort?.Field, model.Sort?.Order == "ASC", skip, model.Pagination.PerPage, out _total);
            return Json(ServiceListResult<object>.Instance.SuccessResult(response.Value, _total));
        }
        protected ActionResult Get0(string id)
        {
            var response = BookMongoBusinessLogic.GetBy(x => x.Id == id);
            return Json(response);
        }
        protected ActionResult Create0(BookMongoEntityModel model)
        {
            //entity.CreatedAt = DateTime.Now;
            var responseInsert = BookMongoBusinessLogic.Add(model.ToEntity());
            return Json(responseInsert);
        }
        protected ActionResult Update0(BookMongoEntityModel model)
        {
            //entity.UpdatedAt = DateTime.Now;
            var responseEdit = BookMongoBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult Delete0(string id)
        {
            var response = BookMongoBusinessLogic.DeleteBy(x => x.Id == id);
            return Json(response);
        }
    }
}
