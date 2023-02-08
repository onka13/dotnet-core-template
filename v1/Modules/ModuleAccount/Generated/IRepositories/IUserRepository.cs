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
using ModuleAccount.Generated.Entities;
using ModuleAccount.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleAccount.IRepositories
{
    public partial interface IUserRepository : IEntityFrameworkBaseRepository<UserEntity>
    {
        
        int DeleteById(int id);
        UserEntity GetById(int id, bool includeRelations = false);
        int DeleteByEmail(string email);
        UserEntity GetByEmail(string email, bool includeRelations = false);
        List<object> Search(int? id,string name,string email,bool? emailConfirmed,Status? status, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
