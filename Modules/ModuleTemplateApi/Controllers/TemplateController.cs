using System;
using Microsoft.AspNetCore.Mvc;
using ModuleAccountApi.Components;
using ModuleTemplateApi.Models;

namespace ModuleTemplateApi.Controllers
{
    /// <summary>
    /// Template controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleTemplateApiController : PublicBaseController
    {
        /// <summary>
        /// Test method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("test")]
        public ActionResult Get(TemplateModel model)
        {
            return Json(new { date = DateTime.UtcNow, model });
        }        
    }
}
