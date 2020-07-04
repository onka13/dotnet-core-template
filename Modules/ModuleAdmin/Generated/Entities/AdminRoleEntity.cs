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
    public class AdminRoleEntityModel : IEntityBase
    {
		[Key]
		[Column(Order=0)]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

        
        public AdminRoleEntity ToEntity()
        {
            return new AdminRoleEntity
            {
                Id=Id,
				Name=Name
            };
        }
    }

    [Table("AdminRole", Schema = "dbo")]
    public class AdminRoleEntity : AdminRoleEntityModel
    {
        
        [InverseProperty("Role")]
        public virtual ICollection<AdminUserRoleMapEntity> AdminUserRoleMapsRole { get; set; }
        
    }
}