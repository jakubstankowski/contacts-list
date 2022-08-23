namespace Contacts_List.Domain.Models.Authentication
{
    /// <summary>
    ///  Modelrejestracji użytkownika
    /// </summary>
    public class Register
    {
        public string DisplayName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Username { get; set; } = null!;
    }
}
