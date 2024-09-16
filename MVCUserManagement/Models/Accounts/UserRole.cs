using System.Collections.Generic;

namespace MVCUserManagement.Models
{
    //[Validator(typeof(RoleValidation))]
    public class UserRole
    {
        public int RoleId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    public class RoleValidation
    {
    }
}