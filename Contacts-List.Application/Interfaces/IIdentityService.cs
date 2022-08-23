using Microsoft.AspNetCore.Identity;

namespace Contacts_List.Application.Interfaces
{
    public interface IIdentityService
    {
        public string GenerateToken(IdentityUser user);

    }
}
