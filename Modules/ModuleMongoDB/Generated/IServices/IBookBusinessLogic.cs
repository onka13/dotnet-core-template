using CoreCommon.Data.MongoDBBase.Base;
using ModuleMongoDB.Generated.Entities;

namespace ModuleMongoDB.IServices
{
    public partial interface IBookBusinessLogic : IMongoDBBaseBusinessLogic<BookEntity>
    {
	}
}    
