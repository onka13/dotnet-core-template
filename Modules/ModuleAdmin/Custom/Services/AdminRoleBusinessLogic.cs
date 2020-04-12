using System.Collections.Generic;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using CoreCommon.Data.Domain.Business;
using ModuleAdmin.IServices;
using System;
using System.Linq;

namespace ModuleAdmin.Services
{
    public partial class AdminRoleBusinessLogic
    {
        public IAdminRoleDefinitionBusinessLogic RoleDefinitionBusinessLogic { get; set; }

        public ServiceResult<object> SaveMap(List<string> roles)
        {
            var response = ServiceResult<object>.Instance.ErrorResult(ServiceResultCode.Error);

            var currentRoles = RoleDefinitionBusinessLogic.GetAll().Value;

            var newRoles = new List<AdminRoleDefinitionEntity>();
            var existsIds = new List<int>();

            foreach (var roleString in roles)
            {
                var roleArr = roleString.Split("_");
                if (roleArr.Length != 4) continue;
                var entity = new AdminRoleDefinitionEntity
                {
                    RoleId = Convert.ToInt32(roleArr[0]),
                    ModuleKey = roleArr[1],
                    PageKey = roleArr[2],
                    ActionKey = roleArr[3],
                    Action = ErpMainRoleAction.Allow
                };
                var exist = currentRoles.FirstOrDefault(x => x.ModuleKey == entity.ModuleKey && x.PageKey == entity.PageKey && x.ActionKey == entity.ActionKey);
                if (exist == null)
                {
                    newRoles.Add(entity);
                }
                else
                {
                    existsIds.Add(exist.Id);
                }
            }

            var deletedRoles = currentRoles.Where(x => !existsIds.Any(y => y == x.Id)).ToList();

            return response.SuccessResult(new
            {
                insert = RoleDefinitionBusinessLogic.BulkInsert(newRoles).Value,
                delete = RoleDefinitionBusinessLogic.BulkDelete(deletedRoles).Value
            });
        }
    }
}
