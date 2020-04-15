
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ModuleAccount.Generated.Entities;
using ModuleAccount.Generated.Enums;

using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;

namespace ModuleAccount.IServices
{
    public partial interface IUserBusinessLogic : IBusinessLogicBase<UserEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<UserEntity> GetById(int id);
        ServiceResult<int> DeleteByEmail(string email);
        ServiceResult<UserEntity> GetByEmail(string email);
        ServiceResult<List<object>> Search(int? id,string name,string email,bool? emailConfirmed,Status? status, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
