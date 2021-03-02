using FluentValidation;
using NewsWebsiteAPI.Infrastructure.Models.Dto.Requests.Accounts;

namespace NewsWebsiteAPI.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationModelValidator()
        {
            RuleFor(rm => rm.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress()
                .WithMessage("Email is not valid.");

            RuleFor(rm => rm.Password)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Password is not valid");

            RuleFor(rm => rm.FullName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}