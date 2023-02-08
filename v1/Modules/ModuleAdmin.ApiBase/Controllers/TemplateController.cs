using System;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.ApiBase.Models;

namespace ModuleAdmin.ApiBase.Controllers
{
    /// <summary>
    /// Template controller
    /// </summary>
    [ApiController]
    [Route("AdminApi/[controller]")]
    public class ModuleAdminApiController : Controller
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
