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
    public partial class AdminRoleBusinessLogic : EntityFrameworkBaseBusinessLogic<AdminRoleEntity, IAdminRoleRepository>, IAdminRoleBusinessLogic
    {
        public override IAdminRoleRepository Repository { get; set; }
        

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

        public ServiceResult<AdminRoleEntity> GetById(int id)
        {
            var response = ServiceResult<AdminRoleEntity>.Instance.ErrorResult(ServiceResultCode.Error);
            response.Value = Repository.GetById(id);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }

        public ServiceResult<List<object>> Search(string name, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var response = ServiceResult<List<object>>.Instance.ErrorResult(ServiceResultCode.Error); 
            response.Value = Repository.Search(name, orderBy, asc, skip, take, out _total);
            if (response.Value != null)
            {
                response.SuccessResult(response.Value);
            }
            return response;
        }
    }
}
