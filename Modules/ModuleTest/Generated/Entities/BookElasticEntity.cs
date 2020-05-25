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
using CoreCommon.Data.ElasticSearch.Base;
using Nest;

namespace ModuleTest.Generated.Entities
{    
    public class BookElasticEntityModel : IElasticSearchBaseEntity<string>
    {
		[MaxLength(50)]
		[Nest.Keyword(Index = true)]
		public string Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		public decimal? Price { get; set; }

		[MaxLength(50)]
		public string Category { get; set; }

		[MaxLength(50)]
		public string Author { get; set; }

        
        public BookElasticEntity ToEntity()
        {
            return new BookElasticEntity
            {
                Id=Id,
				Name=Name,
				Price=Price,
				Category=Category,
				Author=Author
            };
        }
    }

    [IndexConfig("bookelastic")]
    public class BookElasticEntity : BookElasticEntityModel
    {
                
    }
}