using Application.CustomValidators;
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
    public class PatientAddressDto
    {
        public int ID { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string ContactPersonName { get; set; }
    }

    public class PatientAddressDtoValidator : AbstractValidator<PatientAddressDto>
    {
        public PatientAddressDtoValidator(IAddressTypeRepository addressTypeRepository, IStateRepository stateRepository)
        {
            RuleFor(x => x.AddressLine1)
                .NotEmpty().WithMessage("AddressLine1 field is required")
                .MaximumLength(50);

            RuleFor(x => x.AddressLine2)
                .NotEmpty().WithMessage("AddressLine2 field is required")
                .MaximumLength(50);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City field is required")
                .MaximumLength(50);

            RuleFor(x => x.ContactPersonName)
                .NotEmpty().WithMessage("ContactPersonName field is required")
                .MaximumLength(50);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber field is required")
                .IsPhoneNumber()
                .MaximumLength(20);

            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("MobileNumber field is required")
                .IsPhoneNumber()
                .MaximumLength(20);

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode field is required")
                .IsPhoneNumber()
                .MaximumLength(50);

            RuleFor(x => x.AddressType)
                .NotEmpty().WithMessage("AddressType field is required")
                .Must(c => addressTypeRepository.GetAddressType(c) != null).WithMessage($"AddressType field should only contain one of the following values ({String.Join(',', addressTypeRepository.GetAllAddressTypes(true).Select(c => c.TypeName))})");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State field is required")
                .Must(c => stateRepository.GetState(c) != null).WithMessage("State field is invalid");
        }
    }
}
