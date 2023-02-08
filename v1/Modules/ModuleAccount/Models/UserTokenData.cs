using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleAccount.Models
{
    /// <summary>
    /// This model is used by JWT token.
    /// </summary>
    public class UserTokenData
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
