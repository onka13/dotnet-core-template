using DotNetCommon.Data.Domain.Enums;
using DotNetCommon.Data.Domain.Interfaces;
using DotNetCommon.Data.Domain.Models;

namespace DotNetTemplate.Domain.User;

public partial interface IUserRepository : IEntityFrameworkBaseRepository<UserEntity>
{
    Task<int> DeleteById(string id);

    Task<UserEntity> GetById(string id, bool includeRelations = false);

    Task<int> DeleteByEmail(string email);

    Task<UserEntity> GetByEmail(string email, bool includeRelations = false);

    Task<SearchResult> Search(string id, string email, string name, string company, string facebook, string website, string parentSectorId, string sectorId, Status? status, string orderBy, bool asc, int skip, int take);
}
