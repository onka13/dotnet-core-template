using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using System.Collections.Generic;

namespace ModuleAdmin.Models
{
    public class AdminLoginResponseModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsSuper { get; set; }
        public AdminUserTheme Theme { get; set; }
        public string Token { get; set; }
        public List<AdminRoleDefinitionEntity> Roles { get; set; }
    }
}
