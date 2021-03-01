using FluentValidation;
using NewsWebsiteAPI.Models.Dto.Accounts;

namespace NewsWebsiteAPI.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
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