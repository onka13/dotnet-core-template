using System;
using Microsoft.AspNetCore.Mvc;

namespace CoreTemplate.Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Json(new { date = DateTime.UtcNow });
        }
    }
}
