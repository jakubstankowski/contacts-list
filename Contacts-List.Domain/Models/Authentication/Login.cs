namespace Contacts_List.Domain.Models.Authentication
{
    /// <summary>
    ///  Model rejestracji użytkownika
    /// </summary>
    public class Login
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
