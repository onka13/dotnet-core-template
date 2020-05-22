using ModuleMongoDB.IRepositories;
using ModuleMongoDB.Generated.Entities;
using ModuleMongoDB.Generated.Data;
using System;
using System.Collections.Generic;
using CoreCommon.Data.Domain.Enums;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using CoreCommon.Data.MongoDBBase.Base;

namespace ModuleMongoDB.Repositories
{
    public partial class BookRepository : MongoDBBaseRepository<BookEntity>, IBookRepository
    {
        public override string CollectionName => "Book";

        public BookRepository(MainMongoDBConfig settings) : base(settings)
        {
        }

        public int DeleteById(string id)
        {
            return DeleteBy(x => x.Id == id);
        }

        public BookEntity GetById(string id)
        {
            return GetBy(x => x.Id == id);
        }

        public int DeleteByEmail(string email)
        {
            return DeleteBy(x => x.Author == email);
        }

        public BookEntity GetByEmail(string email)
        {
            return GetBy(x => x.Author == email);
        }

        public List<object> Search(int? id, string name, string email, bool? emailConfirmed, Status? status, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetQueryable();
            if (id.HasValue)
                result = result.Where(x => x.Id.Equals(id));
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            var dic = new Dictionary<string, Expression<Func<BookEntity, object>>>
            {
                {"id", x => x.Id},{"email", x => x.Author}
            };

            Expression<Func<BookEntity, object>> selectFunc = x => new
            {
                x.Id,
                x.Name
            };

            if (!string.IsNullOrEmpty(orderBy) && dic.ContainsKey(orderBy))
            {
                var result2 = asc ? result.OrderBy(x => x.Author) : result.OrderByDescending(dic[orderBy]);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
    }
}
