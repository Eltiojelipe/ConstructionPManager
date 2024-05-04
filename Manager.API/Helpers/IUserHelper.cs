using Manager.Share.Entities;
using Microsoft.AspNetCore.Identity;

namespace Manager.API.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AdduserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}

