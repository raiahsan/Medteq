using Application.CustomValidators;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.ILookupRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums = Domain.Enums;

namespace Application.Dto.Lead
{
    public class LeadContactDto
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public bool IsDefault { get; set; }
        public string ContactMethod { get; set; }
    }

    public class LeadContactDtoValidator : AbstractValidator<LeadContactDto>
    {
        public LeadContactDtoValidator(IContactMethodRepository contactMethodRepository)
        {
            RuleFor(x => x.Email).EmailAddress()
                .When(x => !String.IsNullOrWhiteSpace(x.Email))
                .MaximumLength(100);

            RuleFor(x => x.PhoneNumber).IsPhoneNumber()
                .When(x => !String.IsNullOrWhiteSpace(x.PhoneNumber))
                .MaximumLength(20);

            RuleFor(x => x.MobileNumber).IsPhoneNumber()
                .When(x => !String.IsNullOrWhiteSpace(x.MobileNumber))
                .MaximumLength(20);

            RuleFor(c => c.FaxNumber).MaximumLength(11);

            RuleFor(x => x.ContactMethod)
                .NotEmpty().WithMessage("ContactMethod field is required")
                .Must(c => contactMethodRepository.GetContactMethod(c) != null).WithMessage($"ContactMethod field should only contain one of the following values ({String.Join(',', contactMethodRepository.GetAllContactMethods(true).Select(c => c.Name))})");
        }
    }
}
