using CoreCommon.Data.Domain.Business;
using ModuleAccount.Models;

namespace ModuleAccount.IServices
{
    public partial interface IUserBusinessLogic
    {
        ServiceResult<LoginResponseModel> Login(string email, string password);
        ServiceResult<LoginResponseModel> RegisterUser(string email, string password, string name);
        string GetUserEmail(int userId);
        UserTokenData ValidateToken(string token, out bool isExpired);
    }
}     
