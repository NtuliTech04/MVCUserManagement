using FluentValidation;
using FluentValidation.Attributes;
using MVCUserManagement.Utilities;
using System.Collections.Generic;

namespace MVCUserManagement.Models
{
    [Validator(typeof(RoleValidation))]
    public class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    
    public class RoleValidation : AbstractValidator<UserRole>
    {
        public RoleValidation()
        {
            RuleFor(r => r.RoleName)
                .NotEmpty().WithMessage("Role Name field is required.")
                .MinimumLength(3).WithMessage("Role Name cannot be less than 3 characters.")
                .MaximumLength(30).WithMessage("Role Name cannot be more than 30 characters.")
                .Matches(RegexExpression.ProperCase).WithMessage("Role Name can only be 'Proper Case'.");

            RuleFor(r => r.RoleDescription)
                .MaximumLength(225).WithMessage("Role Description must not exceed 255 characters.")
                .Matches(RegexExpression.SentenceCase).WithMessage("Role Description can only be 'Sentence case'.");
        }
    }
}