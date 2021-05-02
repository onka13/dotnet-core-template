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
using Microsoft.EntityFrameworkCore;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminUserBusinessLogic : IEntityFrameworkBaseBusinessLogic<AdminUserEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminUserEntity> GetById(int id, bool includeRelations = false);
        ServiceResult<List<object>> Search(string name,string email,Status? status,int? id, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
