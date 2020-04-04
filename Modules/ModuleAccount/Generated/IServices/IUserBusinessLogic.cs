using ModuleAccount.Generated.Entities;
using CoreCommon.Data.Domain.Business;

namespace ModuleAccount.IServices
{
    public partial interface IUserBusinessLogic : IBusinessLogicBase<UserEntity>
    {
        ServiceResult<int> DeleteById(int id);
        ServiceResult<UserEntity> GetById(int id);
        ServiceResult<int> DeleteByEmail(string email);
        ServiceResult<UserEntity> GetByEmail(string email);
	}
}    
