/*
Auto generated file. Do not edit!
*/
using MongoDB.Driver;
using CoreCommon.Data.MongoDBBase.Base;
using ModuleTest.Generated.Entities;

namespace ModuleTest.Generated.Data
{
    public class MongoConnectionMongoContext : MongoDbContextBase
    {
        public override string Name { get => "MongoConnection"; }

        
        IMongoCollection<BookMongoEntity> _bookMongoEntity;
        public IMongoCollection<BookMongoEntity> BookMongoEntity => _bookMongoEntity ??= GetCollection<BookMongoEntity>();

    }
}
