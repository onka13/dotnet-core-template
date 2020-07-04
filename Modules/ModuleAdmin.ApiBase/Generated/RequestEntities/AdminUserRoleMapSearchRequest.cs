﻿
using System;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.Generated.Entities;

namespace ModuleAdmin.ApiBase.Generated.RequestEntities
{
    public class AdminUserRoleMapSearchRequest
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}