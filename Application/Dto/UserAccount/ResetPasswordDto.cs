using Application.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UserAccount
{
    public class ResetPasswordDto
    {
        public string Password { get; set; }
        public string ResetToken { get; set; }
    }
    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password field is required")
                .IsPassword()
                .MaximumLength(2000);

            RuleFor(x => x.ResetToken)
              .NotNull().WithMessage("ResetToken field is required")
              .MaximumLength(200);

        }
    }
}
