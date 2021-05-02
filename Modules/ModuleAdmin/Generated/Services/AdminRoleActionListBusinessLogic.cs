/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.EntityFrameworkCore;

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

        public ServiceResult<AdminRoleActionListEntity> GetById(int id, bool includeRelations = false)
        {
            var response = ServiceResult<AdminRoleActionListEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetById(id, includeRelations);
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

        public ServiceResult<List<AdminRoleActionListEntity>> ListByModuleId(int moduleId, bool includeRelations = false)
        {
            var response = ServiceResult<List<AdminRoleActionListEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.ListByModuleId(moduleId, includeRelations);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<List<AdminRoleActionListEntity>> ListByModuleId(int moduleId, int skip, int take, bool includeRelations = false)
        {
            var response = ServiceResult<List<AdminRoleActionListEntity>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.ListByModuleId(moduleId, skip, take, includeRelations);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
