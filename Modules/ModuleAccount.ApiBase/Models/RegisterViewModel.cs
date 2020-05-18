using System.ComponentModel.DataAnnotations;

namespace ModuleAccount.ApiBase.Models
{
    /// <summary>
    /// Register view model
    /// </summary>
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required."), MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        //[DataType(DataType.Password), Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }
    }
}
