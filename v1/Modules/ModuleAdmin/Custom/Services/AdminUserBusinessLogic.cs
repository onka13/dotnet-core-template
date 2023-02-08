using ModuleAdmin.Generated.Entities;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Enums;
using System.Linq;
using ModuleAdmin.Models;
using CoreCommon.Infra.Helpers;
using ModuleAdmin.Components;
using System;

namespace ModuleAdmin.Services
{
    public partial class AdminUserBusinessLogic
    {
        public ServiceResult<int> Upsert(AdminUserEntity model)
        {
            var response = ServiceResult<int>.Instance.ErrorResult(ServiceResultCode.Error);

            var otherNo = Repository.FindBy(x => x.Id != model.Id && x.Email == model.Email).Select(x => x.Id).FirstOrDefault();
            if (otherNo > 0)
            {
                return response.ErrorResult(ServiceResultCodeAdmin.DuplicateEmail);
            }

            if (model.Id == 0)
            {
                var responseAdd = Add(model);
                if (!responseAdd.Success) return response.ErrorResult(responseAdd.Code);
                return response.SuccessResult(responseAdd.Value.Id, ServiceResultCode.Created);
            }
            else
            {
                response = Edit(model);
            }

            return response.SuccessResult(model.Id);
        }

        public ServiceResult<AdminLoginResponseModel> Login(string email, string password)
        {
            var response = ServiceResult<AdminLoginResponseModel>.Instance.ErrorResult(ServiceResultCodeAdmin.UserInvalidCredential);
            // TODO: uncomment on production
            //var userResult = GetBy(x => x.FirmId == firmId && x.DivisionId == divisionId && x.Email == email);
            var userResult = GetBy(x => x.Email == email);
            if (!userResult.Success || userResult.Value == null || userResult.Value?.Id == 0)
            {
                return response;
            }

            if (userResult.Value.Status != Status.Active)
            {
                return response;
            }

            if (userResult.Value.Pass != password)
            {
                return response;
            }

            var tokenData = new AdminTokenData
            {
                UserId = userResult.Value.Id,
                IsSuper = userResult.Value.IsSuper
            };

            string token = AuthHelper.EncryptTicket(userResult.Value.Email, AdminHelper.SecretKey, TimeSpan.FromDays(1), tokenData);

            return response.SuccessResult(new AdminLoginResponseModel
            {
                Token = token,
                Name = userResult.Value.Name,
                UserId = userResult.Value.Id,                
                Theme = userResult.Value.Theme,
                IsSuper = userResult.Value.IsSuper,
            });
        }
    }
}
