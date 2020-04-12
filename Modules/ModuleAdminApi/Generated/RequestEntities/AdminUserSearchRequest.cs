
using System;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.Generated.Entities;

namespace ModuleAdminApi.Generated.RequestEntities
{
    public class AdminUserSearchRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Status? Status { get; set; }
        public int? Id { get; set; }
    }
}
