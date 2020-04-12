using System.Collections.Generic;

namespace ModuleAdminApi.Models
{
    public class AdminRoleMapListRequest
    {
    }

    public class AdminRoleMapSaveRequest
    {
        public List<string> Roles { get; set; }
    }

    public class UserRoleAssignRequest
    {
        public int UserId { get; set; }
        public List<int> Roles { get; set; }
    }
}
