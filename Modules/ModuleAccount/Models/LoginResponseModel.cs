namespace ModuleAccount.Models
{
    /// <summary>
    /// Response model for login and register methods
    /// </summary>
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
