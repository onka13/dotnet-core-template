using System.Collections.Generic;
using ModuleAdmin.Generated.Entities;
using CoreCommon.Data.Domain.Business;
using System;
using ModuleAdmin.Components;
using System.Linq;
using CoreCommon.Data.Domain.Attributes;
using ModuleAdmin.Models;
using System.Reflection;

namespace ModuleAdmin.Services
{
    public partial class AdminRoleActionListBusinessLogic
    {
        public ServiceResult<int> UpdateRoleActionList(List<Assembly> assemblies, Type baseControllerType)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);

            var model = new ModuleRoleJsonModel();

            foreach (var assembly in assemblies)
            {
                var controllers = assembly.GetTypes().Where(x => x.IsSubclassOf(baseControllerType)).ToList();
                foreach (var controlller in controllers)
                {
                    var roleAction = AdminHelper.GetControllerRoleAction(controlller);
                    if (roleAction == null) continue;

                    if (roleAction.ActionKey == "super") continue;
                    if (roleAction.ActionKey == "admin") continue;

                    model.AddOnce(roleAction.ModuleKey);
                    model.Modules[roleAction.ModuleKey].AddOnce(roleAction.PageKey);
                    model.Modules[roleAction.ModuleKey].Pages[roleAction.PageKey].AddOnce(roleAction.ActionKey);

                    foreach (var method in controlller.GetMethods())
                    {
                        var methodRoleAttribute = method.GetCustomAttributes(false).OfType<RoleActionAttribute>().FirstOrDefault();
                        if (methodRoleAttribute == null) continue;
                        if (methodRoleAttribute.ActionKey == "super") continue;
                        if (methodRoleAttribute.ActionKey == "admin") continue;

                        roleAction.ActionKey = methodRoleAttribute.ActionKey;
                        if (!string.IsNullOrEmpty(methodRoleAttribute.ModuleKey))
                            roleAction.ModuleKey = methodRoleAttribute.ModuleKey;
                        if (!string.IsNullOrEmpty(methodRoleAttribute.PageKey))
                            roleAction.PageKey = methodRoleAttribute.PageKey;


                        model.AddOnce(roleAction.ModuleKey);
                        model.Modules[roleAction.ModuleKey].AddOnce(roleAction.PageKey);
                        model.Modules[roleAction.ModuleKey].Pages[roleAction.PageKey].AddOnce(roleAction.ActionKey);
                    }
                }

            }

            //var json = ConversionHelper.Serialize(model);

            var bulkList = new List<AdminRoleActionListEntity>();

            foreach (var module in model.Modules)
            {
                foreach (var page in module.Value.Pages)
                {
                    foreach (var action in page.Value.Actions)
                    {
                        bulkList.Add(new AdminRoleActionListEntity
                        {
                            ModuleId = 0,
                            ModuleKey = module.Key,
                            PageKey = page.Key,
                            ActionKey = action
                        });
                    }
                }
            }

            DeleteBy(x => x.Id > 0);
            return BulkInsert(bulkList);
        }
    }
}
