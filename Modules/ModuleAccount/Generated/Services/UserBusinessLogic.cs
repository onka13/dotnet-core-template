
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ModuleAccount.Generated.Entities;
using ModuleAccount.Generated.Enums;
using ModuleAccount.Repositories;
using ModuleAccount.IServices;
using ModuleAccount.IRepositories;

using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;

namespace ModuleAccount.Services
{
    public partial class UserBusinessLogic : BusinessLogicBase<UserEntity, IUserRepository>, IUserBusinessLogic
    {
        public override IUserRepository Repository { get; set; }
        

        public ServiceResult<int> DeleteById(int id)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.DeleteById(id);
            if (response.Value > 0)
            {
                response.SuccessResult(response.Value, ServiceResultCode.Deleted);
            }
            return response;
        }

        public ServiceResult<UserEntity> GetById(int id)
        {
            var response = ServiceResult<UserEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetById(id);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<int> DeleteByEmail(string email)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.DeleteByEmail(email);
            if (response.Value > 0)
            {
                response.SuccessResult(response.Value, ServiceResultCode.Deleted);
            }
            return response;
        }

        public ServiceResult<UserEntity> GetByEmail(string email)
        {
            var response = ServiceResult<UserEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetByEmail(email);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
