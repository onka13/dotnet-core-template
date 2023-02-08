using CoreCommon.Data.Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleAccount.Models
{
    /// <summary>
    /// Service result codes for Account Module
    /// </summary>
    public class ResponseCodes : ServiceResultCode
    {
        public const int UserInvalidLogin = 100;
        public const int UserLockedout = 101;
    }
}
