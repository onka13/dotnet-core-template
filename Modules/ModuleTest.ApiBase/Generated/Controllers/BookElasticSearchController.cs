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
using ModuleTest.Services;
using ModuleTest.ApiBase.Generated.RequestEntities;
using ModuleTest.Generated.Entities;
using ModuleTest.IServices;

namespace ModuleTest.ApiBase.Generated.Controllers
{
    public partial class BookElasticSearchController : TestApiBaseController
    {
        public IBookElasticBusinessLogic BookElasticBusinessLogic { get; set; }

        protected ActionResult Search0(ApiRequestListModel<BookElasticSearchRequest> model)
        {
            int skip = (model.Pagination.Page - 1) * Math.Min(model.Pagination.PerPage, 200);
            long _total;
            var response = BookElasticBusinessLogic.Search(model.Filter.Id,model.Filter.Name,model.Filter.Price,model.Filter.Category,model.Filter.Author, model.Sort?.Field, model.Sort?.Order == "ASC", skip, model.Pagination.PerPage, out _total);
            return Json(ServiceListResult<BookElasticEntity>.Instance.SuccessResult(response.Value, _total));
        }
        protected ActionResult Get0(string id)
        {
            var response = BookElasticBusinessLogic.GetBy(id);
            return Json(response);
        }
        protected ActionResult Create0(BookElasticEntityModel model)
        {
            //entity.CreatedAt = DateTime.Now;
            var responseInsert = BookElasticBusinessLogic.Add(model.ToEntity());
            return Json(responseInsert);
        }
        protected ActionResult Update0(BookElasticEntityModel model)
        {
            //entity.UpdatedAt = DateTime.Now;
            var responseEdit = BookElasticBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult UpdateOnly0(BookElasticEntityModel model)
        {
            //var responseEdit = BookElasticBusinessLogic.EditOnly(model.ToEntity(), x => x.Name, x => x.Price, x => x.Category, x => x.Author);
            var responseEdit = BookElasticBusinessLogic.Edit(model.ToEntity());
            return Json(responseEdit);
        }
        protected ActionResult Delete0(string id)
        {
            var response = BookElasticBusinessLogic.DeleteBy(id);
            return Json(response);
        }
    }
}
