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
    [RoleAction("TestApi","BookMongo", null)]
    [Route("TestApi/BookMongoSearch")]
    [ApiController]
    public partial class BookMongoSearchController
    {
        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<BookMongoSearchRequest> model)
        {
            return Search0(model);
        }
        [RoleAction("get")]
        [HttpGet("get/{id}")]
        public ActionResult Get(string id)
        {
            return Get0(id);
        }
        /*[RoleAction("get")]
        [HttpPost("gets")]
        public IActionResult Gets(List<int> ids)
        {
            var response = BookMongoBusinessLogic.FindBy(x => ids.Contains(x.Id));
            // return SuccessResponse(response.Value.Select(x => new { x.Id, x.Name }));
            return Json(response);
        }*/
        [RoleAction("new")]
        [HttpPost("new")]
        public ActionResult Create(BookMongoEntityModel model)
        {
            return Create0(model);
        }
        [RoleAction("edit")]
        [HttpPost("update")]
        public ActionResult Update(BookMongoEntityModel model)
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
