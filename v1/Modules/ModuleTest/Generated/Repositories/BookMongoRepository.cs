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
using CoreCommon.Data.MongoDBBase.Base;
using MongoDB.Driver;

namespace ModuleTest.Repositories
{
    public partial class BookMongoRepository : MongoDBBaseRepository<BookMongoEntity, MongoConnectionMongoContext>, IBookMongoRepository
    {

        public int DeleteById(string id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public BookMongoEntity GetById(string id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public List<object> Search(string id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetRelationAggregate();
            if (!string.IsNullOrEmpty(id))
                result = result.Match(x => x.Id.Equals(id));
            if (!string.IsNullOrEmpty(name))
                result = result.Match(x => x.Name.ToLower().Contains(name.ToLower()));
            if (price.HasValue)
                result = result.Match(x => x.Price.Equals(price));
            if (!string.IsNullOrEmpty(category))
                result = result.Match(x => x.Category.ToLower().Contains(category.ToLower()));
            if (!string.IsNullOrEmpty(author))
                result = result.Match(x => x.Author.ToLower().Contains(author.ToLower()));
            var orderField = SortField(orderBy, x => x.Id);

            var selectFunc = Projection(x => new {
                x.Id,
				x.Name,
				x.Price,
				x.Category,
				x.Author
            });
            if (orderField != null)
            {
                var result2 = asc ? result.SortBy(orderField) : result.SortByDescending(orderField);
                return SkipTake(result2.Project(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Project(selectFunc), skip, take, out _total);
        }
            
    }
}
