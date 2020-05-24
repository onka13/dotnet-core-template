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
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminRoleDefinitionBusinessLogic : IEntityFrameworkBaseBusinessLogic<AdminRoleDefinitionEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminRoleDefinitionEntity> GetById(int id);
        ServiceResult<List<object>> Search(int? roleId,string moduleKey,string pageKey,string actionKey, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
