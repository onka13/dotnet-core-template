using ModuleAdmin.Generated.Entities;
using CoreCommon.Data.Domain.Business;
using ModuleAdmin.Models;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminUserBusinessLogic
    {
        ServiceResult<int> Upsert(AdminUserEntity model);
        ServiceResult<AdminLoginResponseModel> Login(string email, string password);
    }
}     
