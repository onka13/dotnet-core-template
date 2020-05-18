using System.ComponentModel.DataAnnotations;

namespace ModuleAccount.ApiBase.Models
{
    /// <summary>
    /// Login view model
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
