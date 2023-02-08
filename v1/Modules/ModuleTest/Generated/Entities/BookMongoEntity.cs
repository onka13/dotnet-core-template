/*
Auto generated file. Do not edit!
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleTest.Generated.Enums;
using CoreCommon.Data.MongoDBBase.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModuleTest.Generated.Entities
{    
    public class BookMongoEntityModel : IMongoDBBaseEntity<BookMongoEntity>
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[MaxLength(50)]
		[BsonElement("id")]
		public string Id { get; set; }

		[BsonDefaultValue(null)]
		[MaxLength(50)]
		[BsonElement("name")]
		public string Name { get; set; }

		[BsonDefaultValue(null)]
		[BsonElement("price")]
		public decimal? Price { get; set; }

		[BsonDefaultValue(null)]
		[MaxLength(50)]
		[BsonElement("category")]
		public string Category { get; set; }

		[BsonDefaultValue(null)]
		[MaxLength(50)]
		[BsonElement("author")]
		public string Author { get; set; }

        public Expression<Func<BookMongoEntity, bool>> PrimaryPredicate() => x => x.Id == Id;
        public BookMongoEntity ToEntity()
        {
            return new BookMongoEntity
            {
                Id=Id,
				Name=Name,
				Price=Price,
				Category=Category,
				Author=Author
            };
        }
    }

    [Collection("bookMongo")]
    [BsonIgnoreExtraElements]
    public class BookMongoEntity : BookMongoEntityModel
    {
        

        public BookMongoEntityModel ToModel()
        {
            return this;
        }
    }
}