
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.Repositories;
using ModuleAdmin.IServices;
using ModuleAdmin.IRepositories;

using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAdmin.Services
{
    public partial class AdminUserRoleMapBusinessLogic : EntityFrameworkBaseBusinessLogic<AdminUserRoleMapEntity, IAdminUserRoleMapRepository>, IAdminUserRoleMapBusinessLogic
    {
        public override IAdminUserRoleMapRepository Repository { get; set; }
        

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

        public ServiceResult<AdminUserRoleMapEntity> GetById(int id)
        {
            var response = ServiceResult<AdminUserRoleMapEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetById(id);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<int> DeleteByUserId(int userId)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.DeleteByUserId(userId);
            if (response.Value > 0)
            {
                response.SuccessResult(response.Value, ServiceResultCode.Deleted);
            }
            return response;
        }

        public ServiceResult<List<AdminUserRoleMapEntity>> ListByUserId(int userId)
        {
            var response = ServiceResult<List<AdminUserRoleMapEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.ListByUserId(userId);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<List<AdminUserRoleMapEntity>> ListByUserId(int userId, int skip, int take)
        {
            var response = ServiceResult<List<AdminUserRoleMapEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.ListByUserId(userId, skip, take);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<List<object>> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var response = ServiceResult<List<object>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.Search(userId,roleId, orderBy, asc, skip, take, out _total);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
