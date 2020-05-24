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
using ModuleTest.Generated.Entities;
using ModuleTest.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleTest.IServices
{
    public partial interface IBookEfBusinessLogic : IEntityFrameworkBaseBusinessLogic<BookEfEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<BookEfEntity> GetById(int id);
        ServiceResult<List<object>> Search(int? id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
