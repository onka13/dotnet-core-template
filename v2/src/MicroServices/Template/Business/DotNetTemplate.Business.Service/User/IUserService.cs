using DotNetCommon.Data.Domain.Models;

namespace DotNetTemplate.Business.Service.User;

public interface IUserService
{
    Task<AuthResponse> Login(string email, string password);

    Task Register(string email, string password, string name);
}
