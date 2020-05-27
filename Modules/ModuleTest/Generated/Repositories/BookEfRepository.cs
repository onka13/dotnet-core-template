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

namespace ModuleTest.Repositories
{
    public partial class BookEfRepository : EntityFrameworkBaseRepository<BookEfEntity, MainConnectionDbContext>, IBookEfRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public BookEfEntity GetById(int id)
        {
            return GetBy(x => x.Id == id);
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
            var dic = new Dictionary<string, Expression<Func<BookEfEntity, object>>>
            {
                {"id", x => x.Id}
            };

            Expression<Func<BookEfEntity, object>> selectFunc = x => new {
                x.Id,
				x.Name,
				x.Price,
				x.Category,
				x.Author
            };
            if (!string.IsNullOrEmpty(orderBy) && dic.ContainsKey(orderBy))
            {
                var result2 = asc ? result.OrderBy(dic[orderBy]) : result.OrderByDescending(dic[orderBy]);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
            
    }
}
