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
    [RoleAction("TestApi","BookEf", null)]
    [Route("TestApi/BookEfSearch")]
    [ApiController]
    public partial class BookEfSearchController
    {
        [RoleAction("list")]
        [HttpPost("all")]
        public ActionResult Search(ApiRequestListModel<BookEfSearchRequest> model)
        {
            return Search0(model);
        }
        [RoleAction("get")]
        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            return Get0(id);
        }
        /*[RoleAction("get")]
        [HttpPost("gets")]
        public IActionResult Gets(List<int> ids)
        {
            var response = BookEfBusinessLogic.FindBy(x => ids.Contains(x.Id));
            // return SuccessResponse(response.Value.Select(x => new { x.Id, x.Name }));
            return Json(response);
        }*/
        [RoleAction("new")]
        [HttpPost("new")]
        public ActionResult Create(BookEfEntityModel model)
        {
            return Create0(model);
        }
        [RoleAction("edit")]
        [HttpPost("update")]
        public ActionResult Update(BookEfEntityModel model)
        {
            return Update0(model);
        }
        [RoleAction("delete")]
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Delete0(id);
        }
    }
}
