using MVCUserManagement.Models;
using System.Threading.Tasks;

namespace MVCUserManagement.Abstractions.Interfaces
{
    public interface IUserRoles
    {
        Task CreateRoleAsync(UserRole role);
    }
}
