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
using ModuleTest.IRepositories;
using ModuleTest.Generated.Data;
using CoreCommon.Data.ElasticSearch.Base;
using Nest;

namespace ModuleTest.Repositories
{
    public partial class BookElasticRepository : ElasticSearchBaseRepository<BookElasticEntity, string>, IBookElasticRepository
    {
		public override string ConnectionName => "ElasticConnection";

        public List<BookElasticEntity> Search(string id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total)
        {
            Func<QueryContainerDescriptor<BookElasticEntity>, QueryContainer> query = q =>
            {
                QueryContainer container = null;
            if (!string.IsNullOrEmpty(id))
                 container &= q.QueryString(p => p.DefaultField(f => f.Id).Query("*" + id + "*"));
            if (!string.IsNullOrEmpty(name))
                 container &= q.QueryString(p => p.DefaultField(f => f.Name).Query("*" + name + "*"));
            if (price.HasValue)
                 container &= q.Term(p => p.Price, price);
            if (!string.IsNullOrEmpty(category))
                 container &= q.QueryString(p => p.DefaultField(f => f.Category).Query("*" + category + "*"));
            if (!string.IsNullOrEmpty(author))
                 container &= q.QueryString(p => p.DefaultField(f => f.Author).Query("*" + author + "*"));
                return container;
            };
            var selectFields = new Expression<Func<BookElasticEntity, object>>[]
            {
                x => x.Id,
				x => x.Name,
				x => x.Price,
				x => x.Category,
				x => x.Author
            };
            return Search(skip, take, query, selectFields, orderBy, asc, out _total);
        }
            
    }
}
