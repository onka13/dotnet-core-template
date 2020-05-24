/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Business;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAdmin.IRepositories
{
    public partial interface IAdminRoleRepository : IEntityFrameworkBaseRepository<AdminRoleEntity>
    {
        
        int DeleteById(int id);
        AdminRoleEntity GetById(int id);
        List<object> Search(string name, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
