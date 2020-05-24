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
using ModuleTest.Generated.Entities;
using ModuleTest.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleTest.IRepositories
{
    public partial interface IBookEfRepository : IEntityFrameworkBaseRepository<BookEfEntity>
    {
        
        int DeleteById(int id);
        BookEfEntity GetById(int id);
        List<object> Search(int? id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
