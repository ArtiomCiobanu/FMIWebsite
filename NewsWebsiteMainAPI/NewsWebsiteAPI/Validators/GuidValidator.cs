﻿using System;
using FluentValidation;

namespace NewsWebsiteAPI.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid)
                .NotEmpty()
                .WithMessage("Guid must not be empty");
        }
    }
}