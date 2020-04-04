using System.ComponentModel.DataAnnotations;

namespace ModuleAccountApi.Models
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
