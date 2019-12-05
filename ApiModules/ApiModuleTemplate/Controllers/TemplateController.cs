using System;
using Microsoft.AspNetCore.Mvc;
using ApiModuleAccount.Components;
using ApiModuleTemplate.Models;

namespace ApiModuleTemplate.Controllers
{
    /// <summary>
    /// Template controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiModuleTemplateController : PublicBaseController
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
