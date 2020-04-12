
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Enums;



namespace ModuleAdmin.Generated.Entities
{    
    public class AdminRoleActionListEntityModel : IEntityBase
    {
        
        [Key]
        [Column(Order=0)]
        public int Id { get; set; }

        public int ModuleId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ModuleKey { get; set; }

        [Required]
        [MaxLength(200)]
        public string PageKey { get; set; }

        [Required]
        [MaxLength(200)]
        public string ActionKey { get; set; }


        public AdminRoleActionListEntity ToEntity()
        {
            return new AdminRoleActionListEntity
            {
                Id=Id,
				ModuleId=ModuleId,
				ModuleKey=ModuleKey,
				PageKey=PageKey,
				ActionKey=ActionKey
            };
        }
    }

    [Table("AdminRoleActionList", Schema = "dbo")]
    public class AdminRoleActionListEntity : AdminRoleActionListEntityModel 
    {
        
    }
}