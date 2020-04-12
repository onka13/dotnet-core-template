using System.Collections.Generic;
using ModuleAdmin.Generated.Entities;
using CoreCommon.Data.Domain.Business;
using ModuleAdmin.IServices;
using System.Linq;

namespace ModuleAdmin.Services
{
    public partial class AdminUserRoleMapBusinessLogic
    {
        public IAdminRoleBusinessLogic RoleBusinessLogic { get; set; }

        public ServiceResult<object> SaveUserRoles(int userId, List<int> roleIds)
        {
            var response = ServiceResult<object>.Instance.ErrorResult(ServiceResultCode.Error);

            var currentRoles = ListByUserId(userId).Value;
            var roles = RoleBusinessLogic.FindBy(x => roleIds.Contains(x.Id)).Value;

            var newRoles = new List<AdminUserRoleMapEntity>();
            var existsIds = new List<int>();

            foreach (var role in roles)
            {
                var entity = new AdminUserRoleMapEntity
                {
                    RoleId = role.Id,
                    UserId = userId
                };
                var exist = currentRoles.FirstOrDefault(x => x.RoleId == role.Id);
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

            response = response.SuccessResult(new
            {
                insert = BulkInsert(newRoles).Value,
                delete = BulkDelete(deletedRoles).Value
            });
            response.Code = ServiceResultCode.Updated;
            return response;
        }
    }
}
