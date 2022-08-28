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
    public class PatientContactDto
    {
        public int ID { get; set; }
        public string ContactType { get; set; }
        public string RelationshipType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool Active { get; set; }
    }
    public class PatientContactDtoValidator : AbstractValidator<PatientContactDto>
    {
        public PatientContactDtoValidator(
            IContactTypeRepository contactTypeRepository, 
            IRelationshipTypeRepository relationshipTypeRepository,
            IStateRepository stateRepository)
        {
            RuleFor(x => x.AddressLine1).MaximumLength(50);

            RuleFor(x => x.AddressLine2).MaximumLength(50);

            RuleFor(x => x.City).MaximumLength(50);

            //RuleFor(x => x.State).MaximumLength(50);

            RuleFor(x => x.Email)
                .EmailAddress().When(c => !String.IsNullOrWhiteSpace(c.Email))
                .MaximumLength(100);


            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName field is required")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName field is required")
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
                .IsPhoneNumber()
                .MaximumLength(50);

            RuleFor(x => x.ContactType)
                .NotEmpty().WithMessage("ContactType field is required")
                .Must(c => contactTypeRepository.GetContactType(c) != null).WithMessage($"ContactType field should only contain one of the following values ({String.Join(',', contactTypeRepository.GetAllContactTypes(true).Select(c => c.Type))})");

            RuleFor(x => x.RelationshipType)
                .NotEmpty().WithMessage("RelationshipType field is required")
                .Must(c => relationshipTypeRepository.GetRelationshipType(c) != null).WithMessage($"RelationshipType field should only contain one of the following values ({String.Join(',', relationshipTypeRepository.GetAllRelationshipTypes(true).Select(c => c.Type))})");

            RuleFor(x => x.FaxNumber).MaximumLength(11);

            RuleFor(c => c.State).Must(state => stateRepository.GetState(state) != null)
               .When(c => !String.IsNullOrWhiteSpace(c.State))
               .WithMessage("State is invalid");
        }
    }
}
