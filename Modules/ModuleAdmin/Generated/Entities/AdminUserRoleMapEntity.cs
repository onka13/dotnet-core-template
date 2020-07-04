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
    public class AdminUserRoleMapEntityModel : IEntityBase
    {
		[Key]
		[Column(Order=0)]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int RoleId { get; set; }

        
        public AdminUserRoleMapEntity ToEntity()
        {
            return new AdminUserRoleMapEntity
            {
                Id=Id,
				UserId=UserId,
				RoleId=RoleId
            };
        }
    }

    [Table("AdminUserRoleMap", Schema = "dbo")]
    public class AdminUserRoleMapEntity : AdminUserRoleMapEntityModel
    {
        
        [ForeignKey("RoleId")]
        public virtual AdminRoleEntity Role { get; set; }
        
    }
}