using FluentValidation.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCUserManagement.Models
{
    [Validator(typeof(RoleValidation))]
    public class UserRole
    {
        public UserRole(string roleName) 
        {
        }

        public int RoleId { get; set; }
        public int RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }


    public class RoleValidation
    {
    }
}