using Application.CustomValidators;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums = Domain.Enums;

namespace Application.Dto.Patient
{
    public class CreatePatientDto
    {
        public int ID { get; set; }
        public string Branch { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Suffix { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOD { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public DateTime? DateOfDischarge { get; set; }
        public DateTime? DateOfOnset { get; set; }
        public string StateOfAutoAccident { get; set; }
        public string SSN { get; set; }
        public bool? HoldAcct { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int? DiscountPct { get; set; }
        public string AccountNumber { get; set; }
        public bool? HippasignatureOnFile { get; set; }
        public DateTime? MobileVerifiedDate { get; set; }
        public DateTime? EmailVerifiedDate { get; set; }
        public List<PatientAddressDto> Addresses { get; set; }
        public List<PatientContactDto> Contacts { get; set; }
    }
    public class CreatePatientDtoValidator : AbstractValidator<CreatePatientDto>
    {
        public CreatePatientDtoValidator(IGenderRepository genderRepository, IMaritalStatusRepository maritalStatusRepository)
        {
            //RuleFor(x => x.Branch).NotNull().WithMessage("Branch field is required");

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

            RuleFor(x => x.MaritalStatus)
                .Must(c => maritalStatusRepository.GetMaritalStatus(c) != null).WithMessage($"MaritalStatus field should only contain one of the following values ({String.Join(',', maritalStatusRepository.GetAllMaritalStatuses(true).Select(c => c.Value))})")
                .When(x => !String.IsNullOrWhiteSpace(x.MaritalStatus));

            RuleFor(x => x.EmailAddress).EmailAddress()
                .When(x => !String.IsNullOrWhiteSpace(x.EmailAddress))
                .MaximumLength(50);

            RuleFor(x => x.MobilePhone).NotEmpty().WithMessage("MobilePhone field is required")
                .IsPhoneNumber()
                .MaximumLength(20);

            RuleFor(c => c.MiddleName).MaximumLength(50);
            RuleFor(c => c.AccountNumber).MaximumLength(50);
            RuleFor(c => c.FaxNumber).MaximumLength(15);
            RuleFor(c => c.Height).MaximumLength(15);
            RuleFor(c => c.SSN).IsSSN();
            RuleFor(c => c.StateOfAutoAccident).MaximumLength(50);
            RuleFor(c => c.Suffix).MaximumLength(15);
            RuleFor(c => c.Weight).MaximumLength(10);
        }
    }
}
