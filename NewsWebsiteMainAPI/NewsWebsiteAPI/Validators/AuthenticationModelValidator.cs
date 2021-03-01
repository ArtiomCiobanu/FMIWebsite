using FluentValidation;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.Validators
{
    public class AuthenticationModelValidator : AbstractValidator<AuthenticationModel>
    {
        public AuthenticationModelValidator()
        {
            RuleFor(am => am.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress()
                .WithMessage("Email is not valid.");

            RuleFor(am => am.Password)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Password is not valid");
        }
    }
}