using Application.CustomValidators;
using Application.Dto.Branch;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Branch
{
    public class BranchDto
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public string BranchNumber { get; set; }
        public string TaxID { get; set; }
        public string NPI { get; set; }
        public string TaxonomyCode { get; set; }
        public string Region { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool Active { get; set; }
    }
}

public class BranchDtoValidator : AbstractValidator<BranchDto>
{
    public BranchDtoValidator(IStateRepository stateRepository)
    {
        RuleFor(x => x.BranchName)
               .NotNull().WithMessage("BranchName field is required")
               .MaximumLength(50);

        RuleFor(x => x.BranchNumber)
            .NotNull().WithMessage("BranchNumber field is required")
            .MaximumLength(50);

        RuleFor(x => x.Phone)
            .IsPhoneNumber()
            .MaximumLength(15);

        RuleFor(x => x.State)
            .Must(c => stateRepository.GetState(c) != null).WithMessage("State field is invalid")
            .When(c => !String.IsNullOrWhiteSpace(c.State));

        RuleFor(data => data.AddressLine1).MaximumLength(50); 
        RuleFor(data => data.AddressLine2).MaximumLength(50); 
        RuleFor(data => data.City).MaximumLength(50);
        RuleFor(data => data.PostalCode).MaximumLength(10);
        RuleFor(data => data.Fax).MaximumLength(15);

        RuleFor(c => c.NPI).MaximumLength(80);
        RuleFor(c => c.TaxID).MaximumLength(50);
        RuleFor(c => c.TaxonomyCode).MaximumLength(30);
        RuleFor(c => c.Region).MaximumLength(50);
        
       
    }
}




