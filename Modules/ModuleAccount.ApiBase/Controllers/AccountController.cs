using System;
using ModuleAccount.IServices;
using CoreCommon.Data.Domain.Business;
using ModuleAccount.Models;
using Microsoft.AspNetCore.Mvc;
using ModuleAccount.ApiBase.Models;
using ModuleAccount.ApiBase.Components;

namespace ModuleAccount.ApiBase.Controllers
{
    /// <summary>
    /// Account controller
    /// </summary>
    [ApiController]
    [Route("AccountApi/[controller]")]
    public class AccountController : PublicBaseController
    {
        public IUserBusinessLogic UserBusinessLogic { get; set; }

        /// <summary>
        /// Test method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("test")]
        public ServiceResult<DateTime> Get()
        {
            return ServiceResult<DateTime>.Instance.SuccessResult(DateTime.UtcNow);
        }

        /// <summary>
        /// Logins user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult Login(LoginViewModel model)
        {
            //if (!ModelState.IsValid) return InvalidModelResult();
            var response = UserBusinessLogic.Login(model.Email, model.Password);
            return SignIn(response);
        }
        
        /// <summary>
        /// Registers user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return InvalidModelResult();
            var response = UserBusinessLogic.RegisterUser(model.Email, model.Password, model.Name);
            return SignIn(response);
        }

        /// <summary>
        /// Common login and register response 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private ActionResult SignIn(ServiceResult<LoginResponseModel> response)
        {
            if (response.Success)
            {
                Response.Cookies.Append("token", response.Value.Token, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTime.Now.AddMinutes(60),
                    IsEssential = true
                });
                return Json(new { });
            }

            return Json(response);
        }

        /// <summary>
        /// Logouts user
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public ActionResult Logout()
        {
            Response.Cookies.Append("token", "", new Microsoft.AspNetCore.Http.CookieOptions
            {
                HttpOnly = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.Now.AddMinutes(-60),
                IsEssential = true
            });
            return Json(new { result = true });
        }
    }
}
