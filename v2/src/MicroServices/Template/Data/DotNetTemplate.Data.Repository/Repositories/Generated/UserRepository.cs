﻿// <auto-generated />
using DotNetCommon.Data.Domain.Enums;
using DotNetCommon.Data.Domain.Models;
using DotNetCommon.Data.EntityFrameworkBase.Base;
using DotNetTemplate.Data.Repository.DbContext;
using DotNetTemplate.Domain.User;

namespace DotNetTemplate.Data.Repository.Repositories;

public partial class UserRepository : EntityFrameworkBaseRepository<UserEntity, MainConnectionDbContext>, IUserRepository
{
    public async Task<int> DeleteById(string id)
    {
        return await DeleteBy(x => x.Id == id);
    }

    public async Task<UserEntity> GetById(string id, bool includeRelations = false)
    {
        return await GetBy(x => x.Id == id, includeRelations);
    }

    public async Task<int> DeleteByEmail(string email)
    {
        return await DeleteBy(x => x.Email == email);
    }

    public async Task<UserEntity> GetByEmail(string email, bool includeRelations = false)
    {
        return await GetBy(x => x.Email == email, includeRelations);
    }

    public async Task<SearchResult> Search(string id, string email, string name, string company, string facebook, string website, string parentSectorId, string sectorId, Status? status, string orderBy, bool asc, int skip, int take)
    {
        var result = GetRelationQueryable();
        if (!string.IsNullOrEmpty(id))
            result = result.Where(x => x.Id.Equals(id));
        if (!string.IsNullOrEmpty(email))
            result = result.Where(x => x.Email.ToLower().Contains(email.ToLower()));
        if (!string.IsNullOrEmpty(name))
            result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
        
        var orderField = SortField(orderBy, x => x.Id, x => x.Name);

        var selectFunc = Projection(x => new {
            x.Id,
            x.Email,
            x.Name,           
        });
        if (orderField != null)
        {
            var result2 = asc ? result.OrderBy(orderField) : result.OrderByDescending(orderField);
            return await SkipTake(result2.Select(selectFunc), skip, take);
        }
        return await SkipTake(result.Select(selectFunc), skip, take);
    }
}
