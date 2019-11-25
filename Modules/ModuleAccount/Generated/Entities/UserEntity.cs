
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAccount.Generated.Enums;



namespace ModuleAccount.Generated.Entities
{    
    public class UserEntityModel : IEntityBase
    {
        
        [Key]
        [Column(Order=0)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string PasswordHash { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public int AccessFailedCount { get; set; }

        public Status Status { get; set; }


        public UserEntity ToEntity()
        {
            return new UserEntity
            {
                Id=Id,
				Name=Name,
				Email=Email,
				PasswordHash=PasswordHash,
				EmailConfirmed=EmailConfirmed,
				LockoutEndDateUtc=LockoutEndDateUtc,
				AccessFailedCount=AccessFailedCount,
				Status=Status
            };
        }
    }

    [Table("User", Schema = "dbo")]
    public class UserEntity : UserEntityModel 
    {
        
    }
}