
using System;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.Generated.Entities;

namespace ModuleAdmin.ApiBase.Generated.RequestEntities
{
    public class AdminRoleDefinitionSearchRequest
    {
        public int? RoleId { get; set; }
        public string ModuleKey { get; set; }
        public string PageKey { get; set; }
        public string ActionKey { get; set; }
    }
}
