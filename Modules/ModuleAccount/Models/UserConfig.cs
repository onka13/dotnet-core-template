using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleAccount.Models
{
    /// <summary>
    /// User configuration model which defined in appsettings.
    /// </summary>
    public class UserConfig
    {
        public string UserTokenSecret { get; set; }
        public string UserPasswordSalt { get; set; }
    }
}
