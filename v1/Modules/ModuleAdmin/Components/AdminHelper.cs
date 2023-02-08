using CoreCommon.Data.Domain.Attributes;
using CoreCommon.Infra.Helpers;
using Microsoft.AspNetCore.Http;
using ModuleAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ModuleAdmin.Components
{
    public class AdminHelper
    {
        public static string SecretKey = "ADMN_secret_123ADMN_secret_123";
        public static string TokenName = "ADMINTOKEN";

        public static string GetTokenFromHeader(HttpRequestMessage request)
        {
            IEnumerable<string> values;
            if (request.Headers.TryGetValues(TokenName, out values))
            {
                return values.FirstOrDefault().Trim();
            }
            return null;
        }

        public static string GetTokenFromHeader(HttpRequest request)
        {
            var authHeader = request.Headers[TokenName];
            if (authHeader.Count > 0)
            {
                return authHeader[0].Trim();
            }
            return null;
        }

        public static AdminTokenData GetDataFromToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;
            return AuthHelper.DecryptTicket<AdminTokenData>(token, SecretKey);
        }

        public static AdminTokenData GetDataFromToken(string token, out bool isExpired)
        {
            isExpired = true;
            if (string.IsNullOrWhiteSpace(token))
                return null;
            return AuthHelper.DecryptTicket<AdminTokenData>(token, SecretKey, out isExpired);
        }

        public static RoleActionAttribute GetControllerRoleAction(Type controllerType)
        {
            var pageClassRoleAttribute = controllerType.GetCustomAttributes(false).OfType<RoleActionAttribute>().FirstOrDefault();
            if (pageClassRoleAttribute == null)
            {
                return null;
            }

            RoleActionAttribute response = new RoleActionAttribute("");
            response.ModuleKey = controllerType.Namespace.Split('.').FirstOrDefault();
            response.PageKey = controllerType.Name.Replace("SearchController", "").Replace("Controller", "");
            response.ActionKey = pageClassRoleAttribute.ActionKey;
            if (!string.IsNullOrEmpty(pageClassRoleAttribute.ModuleKey))
                response.ModuleKey = pageClassRoleAttribute.ModuleKey;
            if (!string.IsNullOrEmpty(pageClassRoleAttribute.PageKey))
                response.PageKey = pageClassRoleAttribute.PageKey;

            return response;
        }
    }
}
