using Microsoft.AspNetCore.Identity;

namespace Contacts_List.Application.Interfaces
{
    public interface IIdentityService
    {
        public string GenerateToken(IdentityUser user);

        public Task<bool> UserExist(string email);
    }
}
