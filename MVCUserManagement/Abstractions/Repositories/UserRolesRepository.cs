using MVCUserManagement.Models;
using MVCUserManagement.Persistence.Context;
using System;
using System.Threading.Tasks;

namespace MVCUserManagement.Abstractions.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly UserManagementDbContext _context = new UserManagementDbContext();

        public async Task SeedRoleAsync(string roleName)
        {
             await _context.spInsertUserRole(roleName, null);
        }


        public async Task<int> CreateRoleAsync(UserRole userRole)
        {
             return await _context.spInsertUserRole(userRole.RoleName, userRole.RoleDescription);
        }
    }
}