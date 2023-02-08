using System;
using Microsoft.AspNetCore.Mvc;
using ModuleAccount.ApiBase.Components;
using ModuleTemplate.ApiBase.Models;

namespace ModuleTemplate.ApiBase.Controllers
{
    /// <summary>
    /// Template controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
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
