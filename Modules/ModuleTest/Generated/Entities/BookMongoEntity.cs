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
		[BsonRequired]
		[Required]
		[MaxLength(50)]
		[BsonElement("Id")]
		public string Id { get; set; }

		[MaxLength(50)]
		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("Price")]
		public decimal? Price { get; set; }

		[MaxLength(50)]
		[BsonElement("Category")]
		public string Category { get; set; }

		[MaxLength(50)]
		[BsonElement("Author")]
		public string Author { get; set; }

        public Expression<Func<BookMongoEntity, bool>> PrimaryPredicate => x => x.Id == Id;
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

    [Collection("BookMongo")]
    public class BookMongoEntity : BookMongoEntityModel
    {
                
    }
}