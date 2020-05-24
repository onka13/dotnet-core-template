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
using CoreCommon.Data.ElasticSearch.Base;

namespace ModuleTest.IServices
{
    public partial interface IBookElasticBusinessLogic : IElasticSearchBaseBusinessLogic<BookElasticEntity, string>
    {
        
        ServiceResult<List<BookElasticEntity>> Search(string id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
