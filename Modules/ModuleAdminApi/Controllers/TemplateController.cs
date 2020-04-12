using System;
using Microsoft.AspNetCore.Mvc;
using ModuleAdminApi.Models;

namespace ModuleAdminApi.Controllers
{
    /// <summary>
    /// Template controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
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
