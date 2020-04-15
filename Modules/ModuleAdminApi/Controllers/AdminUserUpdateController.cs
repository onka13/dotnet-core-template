using CoreCommon.Data.Domain.Attributes;
using Microsoft.AspNetCore.Mvc;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.IServices;
using ModuleAdminApi.Generated.Controllers;
using System.Linq;

namespace ModuleAdminApi.Controllers
{
    // no role needed
    [Route("AdminApi/AdminUserUpdate")]
    [ApiController]
    public class AdminUserUpdateController : AdminApiBaseController
    {
        public IAdminUserBusinessLogic AdminUserBusinessLogic { get; set; }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var response = AdminUserBusinessLogic.FindBy(x => x.Id == MainTokenData.UserId).Value.Select(x => new
            {
                id = 0,
                x.Name,
                x.Pass,
                x.Language,
                x.Theme
            }).FirstOrDefault();
            return SuccessResponse(response);
        }

        [ModelStateIgnore(new string[] { "Email" })]
        [HttpPost("update")]
        public ActionResult Update(AdminUserEntityModel model)
        {
            model.Id = MainTokenData.UserId;
            var responseEdit = AdminUserBusinessLogic.EditOnly(model.ToEntity(),
                x => x.Name,
                x => x.Pass,
                x => x.Language,
                x => x.Theme
                );
            return Json(responseEdit);
        }
    }
}
