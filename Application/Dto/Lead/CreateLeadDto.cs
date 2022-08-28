using Application.CustomValidators;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILeadRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using Domain.Enums;
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
    public class CreateLeadDto
    {
        public int ID { get; set; }
        public string LeadType { get; set; }
        public string LeadSource { get; set; }
        public string Branch { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string MobilePhone { get; set; }
        public string BillingPostalCode { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorNPI { get; set; }
        public DateTime? DateLastSeenByDoctor { get; set; }
        public int? DiagnosisCode { get; set; }
        public string Notes { get; set; }
        public List<LeadContactDto> LeadContacts { get; set; }
    }
    public class CreateLeadDtoValidator : AbstractValidator<CreateLeadDto>
    {
        public CreateLeadDtoValidator(
            IStateRepository stateRepository,
            ILeadTypeRepository leadTypeRepository,
            ILeadSourceRepository leadSourceRepository,
            IGenderRepository genderRepository)
        {
            RuleFor(x => x.LeadType)
                .NotEmpty().WithMessage("LeadType field is required")
                .Must(c => leadTypeRepository.GetLeadType(c) != null).WithMessage($"LeadType field should only contain one of the following values ({String.Join(',', leadTypeRepository.GetAllLeadTypes(true).Select(c => c.Name))})");

            RuleFor(x => x.LeadSource)
                .NotEmpty().WithMessage("LeadSource field is required")
                .Must(c => leadSourceRepository.GetLeadSource(c) != null).WithMessage($"LeadSource field should only contain one of the following values ({String.Join(',', leadSourceRepository.GetAllLeadSources(true).Select(c => c.Name))})");

            RuleFor(x => x.Branch).NotNull().WithMessage("Branch field is required");

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("FirstName field is required")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("LastName field is required")
                .MaximumLength(50);

            RuleFor(x => x.DOB).NotNull().WithMessage("DOB field is required");
            RuleFor(x => x.Gender)
                .Must(c => genderRepository.GetGender(c) != null).WithMessage($"Gender field should only contain one of the following values ({String.Join(',', genderRepository.GetAllGenders(true).Select(c => c.Value))})")
                .When(x => !String.IsNullOrWhiteSpace(x.Gender));

            RuleFor(x => x.Email).EmailAddress()
                .When(x => !String.IsNullOrWhiteSpace(x.Email))
                .MaximumLength(50);

            RuleFor(x => x.MobilePhone).NotEmpty().WithMessage("MobilePhone field is required")
                .IsPhoneNumber()
                .MaximumLength(20);

            RuleFor(c => c.HomePhone)
                .IsPhoneNumber()
                .MaximumLength(20);

            RuleFor(c => c.BillingAddress1).MaximumLength(50);
            RuleFor(c => c.BillingAddress2).MaximumLength(50);
            RuleFor(c => c.BillingAddress3).MaximumLength(50);
            RuleFor(c => c.BillingCity).MaximumLength(50);
            RuleFor(c => c.BillingPostalCode).MaximumLength(10);
            RuleFor(c => c.DoctorFirstName).MaximumLength(50);
            RuleFor(c => c.DoctorLastName).MaximumLength(50);
            RuleFor(c => c.DoctorNPI).MaximumLength(80);
            RuleFor(c => c.Notes).MaximumLength(2000);
            RuleFor(c => c.BillingState).Must(state => stateRepository.GetState(state) != null)
                .When(c => !String.IsNullOrWhiteSpace(c.BillingState))
                .WithMessage("BillingState is invalid");
        }
    }
}
