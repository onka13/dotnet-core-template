using CoreCommon.Data.Domain.Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiModuleCommon.Components
{
    /// <summary>
    /// Base controller for all controllers
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        /// <summary>
        /// Returns invalid models as ServiceResult error.
        /// </summary>
        /// <returns></returns>
        public ActionResult InvalidModelResult()
        {
            var response = ServiceResult<List<string>>.Instance.ErrorResult(ServiceResultCode.InvalidModel);
            response.Value = new List<string>();
            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count > 0)
                    response.Value.Add(item.Key);
            }
            return Json(response);
        }
    }
}
