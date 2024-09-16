using FluentValidation;
using FluentValidation.Attributes;
using System;
using MVCUserManagement.Utilities;

namespace MVCUserManagement.Models
{
    [Validator(typeof(UserValidation))]
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  ConfirmPassword { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime? InvalidLogin {  get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int? InvalidPasswordAttempts { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsActive { get; set; }


        public int RoleId { get; set; }
        public virtual UserRole Role { get; set; }
    }


    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First Name field is required.")
                .MinimumLength(3).WithMessage("First Name cannot be less than 3 characters.")
                .MaximumLength(30).WithMessage("First Name cannot be more than 30 characters.")
                .Matches(RegexExpression.ProperCase).WithMessage("First Name can only be proper case.");

            RuleFor(r => r.LastName)
               .NotEmpty().WithMessage("Last Name field is required.")
               .MinimumLength(3).WithMessage("Last Name cannot be less than 3 characters.")
               .MaximumLength(30).WithMessage("Last Name cannot be more than 30 characters.")
               .Matches(RegexExpression.ProperCase).WithMessage("Last Name can only be proper case.");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email field is required.")
                .MinimumLength(5).WithMessage("Your email address cannot be less than 5 characters long.")
                .EmailAddress().Matches(RegexExpression.EmailRegex).WithMessage("Invalid email format.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password field is required.")
                .Matches(RegexExpression.PasswordRegex)
                .WithMessage("Password must be between 8 and 20 characters long with at least one uppercase, one lowercase, one digit, and one special character.");

            RuleFor(r => r.ConfirmPassword)
                .NotEmpty().Equal(r => r.Password)
                .WithMessage("The password and confirmation password do not match.");

            RuleFor(r => r.ProfilePhoto)
               .Matches(RegexExpression.ImageRegex)
               .WithMessage("Invalid image format. Only png and jpg are acceptable.");

            RuleFor(r => r.ProfilePhoto.Length)
                .ExclusiveBetween(0, MediaConstants.ImageMaxBytes)
                .WithMessage($"Profile photo size cannot be more than {MediaConstants.ImageMaxMegaBytes} MB")
                .When(r => r.ProfilePhoto != null);
        }
    }
}