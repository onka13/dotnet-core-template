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
using CoreCommon.Data.EntityFrameworkBase.Base;
using Microsoft.EntityFrameworkCore;

namespace ModuleTest.Repositories
{
    public partial class BookEfRepository : EntityFrameworkBaseRepository<BookEfEntity, MainConnectionDbContext>, IBookEfRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public BookEfEntity GetById(int id, bool includeRelations = false)
        {
            return GetBy(x => x.Id == id, includeRelations);
        }

        public List<object> Search(int? id,string name,decimal? price,string category,string author, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (id.HasValue)
                result = result.Where(x => x.Id.Equals(id));
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (price.HasValue)
                result = result.Where(x => x.Price.Equals(price));
            if (!string.IsNullOrEmpty(category))
                result = result.Where(x => x.Category.ToLower().Contains(category.ToLower()));
            if (!string.IsNullOrEmpty(author))
                result = result.Where(x => x.Author.ToLower().Contains(author.ToLower()));
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
                var result2 = asc ? result.OrderBy(orderField) : result.OrderByDescending(orderField);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
            
    }
}
