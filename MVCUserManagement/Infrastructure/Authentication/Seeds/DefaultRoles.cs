using MVCUserManagement.Abstractions;
using MVCUserManagement.Abstractions.Repositories;
using MVCUserManagement.Infrastructure.Authentication.Enums;
using MVCUserManagement.Persistence.Context;
using System.Threading.Tasks;
using System.Linq;

namespace MVCUserManagement.Infrastructure.Authentication.Seeds
{
    public class DefaultRoles
    {
        private readonly UserManagementDbContext _context = new UserManagementDbContext();
        private readonly IUserRolesRepository _roles = new UserRolesRepository();

        public async Task SeedUserRoles()
        {
            if (!_context.UserRoles.Any())
            {
                await _roles.SeedRoleAsync(RoleOptions.Superadmin.ToString());
                await _roles.SeedRoleAsync(RoleOptions.Enduser.ToString());
            }
        }
    }
}