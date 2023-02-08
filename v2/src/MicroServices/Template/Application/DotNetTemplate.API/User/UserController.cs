using DotNetTemplate.API.User.Models;
using DotNetTemplate.Business.Service.User;
using Microsoft.AspNetCore.Mvc;
using Shared.ApplicationWebBase.BaseComponents;

namespace DotNetTemplate.API.User;

[Route("user")]
public class UserController : SharedBaseController
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest model)
    {
        var response = await userService.Login(model.Email, model.Password);
        return Json(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterRequest model)
    {
        await userService.Register(model.Email, model.Password, model.Name);
        return SuccessResponse();
    }
}
