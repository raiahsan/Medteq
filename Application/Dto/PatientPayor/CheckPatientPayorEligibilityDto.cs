using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PatientPayor
{
    public class CheckPatientPayorEligibilityDto
    {
        public string ProviderNPI { get; set; }
        public int PatientPayorID { get; set; }
        //public string ProviderLastName { get; set; }
        //public string ProviderFirstName { get; set; }
        //public string ProviderNPI { get; set; }
        //public string ProviderPIN { get; set; }
        //public string ProviderTaxanomy { get; set; }
        //public string VerificationType { get; set; }
        //public string SubcriberLastName { get; set; }
        //public string SubcriberFirstName { get; set; }
        //public string SubcriberMemberID { get; set; }
        //public string SubcriberSSN { get; set; }
        //public string SubscriberGroupNumber { get; set; }
        //public string DependentLastName { get; set; }
        //public string DependentFirstName { get; set; }
        //public string DependentRelationship { get; set; }
        //public string IssueDate { get; set; }
        //public string DateOfServiceFrom { get; set; }
        //public string DateOfServiceTo { get; set; }
        //public string BatchName { get; set; }
        //public string ServiceCodes { get; set; }
        //public string Notes { get; set; }
        //public bool Manual { get; set; }
    }

    public class CheckPatientPayorEligibilityDtoValidator : AbstractValidator<CheckPatientPayorEligibilityDto>
    {
        public CheckPatientPayorEligibilityDtoValidator()
        {
            RuleFor(x => x.ProviderNPI)
                .NotEmpty().WithMessage("ProviderNPI field is required");

            RuleFor(x => x.PatientPayorID)
                .NotEmpty().WithMessage("PatientPayorID field is required");

            //RuleFor(c => c.BatchName).MaximumLength(50);
            //RuleFor(c => c.DateOfServiceFrom).MaximumLength(50);
            //RuleFor(c => c.DateOfServiceTo).MaximumLength(50);
            //RuleFor(c => c.DependentFirstName).MaximumLength(50);
            //RuleFor(c => c.DependentLastName).MaximumLength(50);
            //RuleFor(c => c.DependentRelationship).MaximumLength(80);
            //RuleFor(c => c.IssueDate).MaximumLength(50);
            //RuleFor(c => c.Notes).MaximumLength(2000);
            //RuleFor(c => c.ProviderFirstName).MaximumLength(50);
            //RuleFor(c => c.ProviderLastName).MaximumLength(50);
            //RuleFor(c => c.ProviderNPI).MaximumLength(50);
            //RuleFor(c => c.ProviderPIN).MaximumLength(50);
            //RuleFor(c => c.ProviderTaxanomy).MaximumLength(80);
            //RuleFor(c => c.ServiceCodes).MaximumLength(50);
            //RuleFor(c => c.SubcriberFirstName).MaximumLength(50);
            //RuleFor(c => c.SubcriberLastName).MaximumLength(50);
            //RuleFor(c => c.SubcriberMemberID).MaximumLength(50);
            //RuleFor(c => c.SubcriberSSN).MaximumLength(50);
            //RuleFor(c => c.SubscriberGroupNumber).MaximumLength(50);
            //RuleFor(c => c.VerificationType).MaximumLength(50);
        }
    }
}
