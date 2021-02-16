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
using CoreCommon.Data.ElasticSearch.Base;
using Nest;

namespace ModuleTest.IRepositories
{
    public partial interface IBookElasticRepository : IElasticSearchBaseRepository<BookElasticEntity, string>
    {
        
        List<BookElasticEntity> Search(string id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
