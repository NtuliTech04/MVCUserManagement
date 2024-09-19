using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCUserManagement.Abstractions.Interfaces;
using MVCUserManagement.Infrastructure.Authentication.Enums;
using MVCUserManagement.Models;
using MVCUserManagement.Persistence.Context;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUserManagement.Infrastructure.Authentication.Seeds
{
    public class DefaultRoles
    {
        private readonly UserManagementDbContext _context;
        private readonly IUserRoles _roles;
        public DefaultRoles(IUserRoles userRoles, UserManagementDbContext dbContext)
        {
            _roles = userRoles;
            _context = dbContext;
        }
        

        public async Task SeedUserRoles()
        {
            if (!_context.UserRoles.Any())
            {
                await _roles.CreateRoleAsync(new UserRole(RoleOptions.Admin.ToString()));
                await _roles.CreateRoleAsync(new UserRole(RoleOptions.User.ToString()));
            }
        }
    }
}