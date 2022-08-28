using Application.CustomValidators;
using Application.Dto.UserAccount;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IUserServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UserAccount
{
    public class UserUpsertDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int RoleID { get; set; }
    }

    public class UserUpsertDtoValidator : AbstractValidator<UserUpsertDto>
    {
        public UserUpsertDtoValidator(IUsersService usersService)
        {
            RuleFor(x => x.FirstName)
              .NotNull().WithMessage("FirstName field is required")
              .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("LastName field is required")
                .MaximumLength(50);

            When(c => c.ID == 0, () =>
            {
                RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password field is required");
                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email field is required")
                    .Must(c => usersService.GetByEmail(c) == null).WithMessage("Email already exists");
            });

            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(150);

            RuleFor(x => x.Password)
                .IsPassword()
                .MaximumLength(2000);

            RuleFor(x => x.RoleID)
               .NotEmpty().WithMessage("RoleID field is required");

        }
    }

}





