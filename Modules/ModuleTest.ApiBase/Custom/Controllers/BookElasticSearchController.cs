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
    [RoleAction("TestApi","BookElastic", null)]
    [Route("TestApi/BookElasticSearch")]
    [ApiController]
    public partial class BookElasticSearchController
    {
        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<BookElasticSearchRequest> model)
        {
            return Search0(model);
        }
        [RoleAction("get")]
        [HttpGet("get/{id}")]
        public ActionResult Get(string id)
        {
            return Get0(id);
        }
        [RoleAction("get")]
        [HttpPost("gets")]
        public IActionResult Gets(List<string> ids)
        {
            var response = BookElasticBusinessLogic.GetMany(ids);
            // return SuccessResponse(response.Value.Select(x => new { x.Id, x.Name }));
            return Json(response);
        }
        [RoleAction("new")]
        [HttpPost("new")]
        public ActionResult Create(BookElasticEntityModel model)
        {
            return Create0(model);
        }
        [RoleAction("edit")]
        [HttpPost("update")]
        public ActionResult Update(BookElasticEntityModel model)
        {
            return Update0(model);
        }
        [RoleAction("delete")]
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(string id)
        {
            return Delete0(id);
        }
    }
}
