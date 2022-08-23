namespace Contacts_List.Domain.Models.User
{
    /// <summary>
    ///  Model użytkownika
    /// </summary>
    public class User
    {
        public string Token { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
