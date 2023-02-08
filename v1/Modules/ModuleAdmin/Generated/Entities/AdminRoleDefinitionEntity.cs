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
using ModuleAdmin.Generated.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;

namespace ModuleAdmin.Generated.Entities
{    
    public class AdminRoleDefinitionEntityModel : IEntityBase
    {
		[Key]
		[Column(Order=0)]
		public int Id { get; set; }

		[Required]
		public int RoleId { get; set; }

		[MaxLength(50)]
		public string ModuleKey { get; set; }

		[MaxLength(50)]
		public string PageKey { get; set; }

		[MaxLength(50)]
		public string ActionKey { get; set; }

		[Required]
		public AdminRoleAction Action { get; set; }

        
        public AdminRoleDefinitionEntity ToEntity()
        {
            return new AdminRoleDefinitionEntity
            {
                Id=Id,
				RoleId=RoleId,
				ModuleKey=ModuleKey,
				PageKey=PageKey,
				ActionKey=ActionKey,
				Action=Action
            };
        }
    }

    [Table("AdminRoleDefinition", Schema = "dbo")]
    public class AdminRoleDefinitionEntity : AdminRoleDefinitionEntityModel
    {
        

        public AdminRoleDefinitionEntityModel ToModel()
        {
            return this;
        }
    }
}