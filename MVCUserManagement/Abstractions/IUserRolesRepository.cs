using MVCUserManagement.Models;
using System.Threading.Tasks;

namespace MVCUserManagement.Abstractions
{
    public interface IUserRolesRepository
    {
        Task SeedRoleAsync(string roleName);
        Task<int> CreateRoleAsync(UserRole userRole);
    }
}
