using CoreCommon.Data.MongoDBBase.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Linq.Expressions;

namespace ModuleMongoDB.Generated.Entities
{
    public class BookEntity : IMongoDBBaseEntity<BookEntity>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }

        //[BsonDefaultValue(0)]
        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonRequired]
        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        public Expression<Func<BookEntity, bool>> PrimaryPredicate => x => x.Id == Id;
    }
}
