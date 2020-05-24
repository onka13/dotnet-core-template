/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.Repositories;
using ModuleAdmin.IServices;
using ModuleAdmin.IRepositories;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAdmin.Services
{
    public partial class AdminRoleActionListBusinessLogic : EntityFrameworkBaseBusinessLogic<AdminRoleActionListEntity, IAdminRoleActionListRepository>, IAdminRoleActionListBusinessLogic
    {
        public override IAdminRoleActionListRepository Repository { get; set; }
        

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

        public ServiceResult<AdminRoleActionListEntity> GetById(int id)
        {
            var response = ServiceResult<AdminRoleActionListEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetById(id);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<int> DeleteByModuleId(int moduleId)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.DeleteByModuleId(moduleId);
            if (response.Value > 0)
            {
                response.SuccessResult(response.Value, ServiceResultCode.Deleted);
            }
            return response;
        }

        public ServiceResult<List<AdminRoleActionListEntity>> ListByModuleId(int moduleId)
        {
            var response = ServiceResult<List<AdminRoleActionListEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.ListByModuleId(moduleId);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<List<AdminRoleActionListEntity>> ListByModuleId(int moduleId, int skip, int take)
        {
            var response = ServiceResult<List<AdminRoleActionListEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.ListByModuleId(moduleId, skip, take);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
