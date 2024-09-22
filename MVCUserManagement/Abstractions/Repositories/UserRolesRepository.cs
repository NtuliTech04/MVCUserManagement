using MVCUserManagement.Persistence.Context;
using System.Threading.Tasks;

namespace MVCUserManagement.Abstractions.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly UserManagementDbContext _context = new UserManagementDbContext();

        public async Task SeedRoleAsync(string roleName)
        {
             await _context.InsertUserRole(roleName, null);
        }
    }
}