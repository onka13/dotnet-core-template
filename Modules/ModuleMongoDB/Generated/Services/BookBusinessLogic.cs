using CoreCommon.Data.MongoDBBase.Base;
using ModuleMongoDB.Generated.Entities;
using ModuleMongoDB.IRepositories;
using ModuleMongoDB.IServices;

namespace ModuleMongoDB.Services
{
    public partial class BookBusinessLogic : MongoDBBaseBusinessLogic<BookEntity, IBookRepository>, IBookBusinessLogic
    {
        public override IBookRepository Repository { get; set; }


    }
}
