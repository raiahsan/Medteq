﻿using Application.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.UserAccount
{
    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator()
        {
            RuleFor(x => x.CurrentPassword)
               .NotEmpty()
               .WithMessage("Password field is required")
               .MaximumLength(2000);

            RuleFor(x => x.NewPassword)
               .NotEmpty()
               .WithMessage("Password field is required")
               .IsPassword()
               .MaximumLength(2000)
               .NotEqual(x => x.CurrentPassword);
        }
    }
}
