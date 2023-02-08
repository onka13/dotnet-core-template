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
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleTest.Generated.Entities
{    
    public class BookEfEntityModel : IEntityBase
    {
		[Key]
		[Column(Order=0)]
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		public decimal? Price { get; set; }

		[MaxLength(50)]
		public string Category { get; set; }

		[MaxLength(50)]
		public string Author { get; set; }

        
        public BookEfEntity ToEntity()
        {
            return new BookEfEntity
            {
                Id=Id,
				Name=Name,
				Price=Price,
				Category=Category,
				Author=Author
            };
        }
    }

    [Table("BookEf", Schema = "dbo")]
    public class BookEfEntity : BookEfEntityModel
    {
        

        public BookEfEntityModel ToModel()
        {
            return this;
        }
    }
}