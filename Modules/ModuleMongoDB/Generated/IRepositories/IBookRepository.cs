using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.MongoDBBase.Base;
using ModuleMongoDB.Generated.Entities;

namespace ModuleMongoDB.IRepositories
{
    public partial interface IBookRepository : IMongoDBBaseRepository<BookEntity>
    {
        
	}
}    
