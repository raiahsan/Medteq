using Application.CustomValidators;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using Application.RepositoryInterfaces.IPatientRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PatientPayor
{
    public class CreatePatientPayorDto
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int PayorID { get; set; }
        public string PayorLevel { get; set; }
        public string PolicyHolderGender { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyHolderName { get; set; }
        public DateTime? PolicyHolderDOB { get; set; }
        public string GroupNumber { get; set; }
        public string Bin { get; set; }
        public string Pcn { get; set; }
        public string NCDPDPolicyNumber { get; set; }
        public string NCPDPGroupNumber { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredPhone { get; set; }
        public string InsuredAddress1 { get; set; }
        public string InsuredAddress2 { get; set; }
        public string InsuredCity { get; set; }
        public string InsuredState { get; set; }
        public string InsuredZip { get; set; }
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public decimal? PayPercent { get; set; }
        public decimal? Deductible { get; set; }
        public string GroupName { get; set; }
        public string PayorContact { get; set; }
        public bool? InsVerified { get; set; }
        public string InsVerifiedBy { get; set; }
        public DateTime? InsVerifiedDate { get; set; }
        public string VerificationType { get; set; }
    }

    public class CreatePatientPayorDtoValidator : AbstractValidator<CreatePatientPayorDto>
    {
        public CreatePatientPayorDtoValidator(IGenderRepository genderRepository, IStateRepository stateRepository, IPayorLevelRepository payorLevelRepository)
        {
            RuleFor(x => x.PayorLevel)
                .NotEmpty().WithMessage("PayorLevel field is required")
                .Must(c => payorLevelRepository.GetPayorLevel(c) != null).WithMessage($"PayorLevel field should only contain one of the following values ({String.Join(',', payorLevelRepository.GetAllPayorLevels(true).Select(c => c.Name))})");

            RuleFor(x => x.PolicyHolderGender)
                .Must(c => genderRepository.GetGender(c) != null).WithMessage($"PolicyHolderGender field should only contain one of the following values ({String.Join(',', genderRepository.GetAllGenders(true).Select(c => c.Value))})")
                .When(x => !String.IsNullOrWhiteSpace(x.PolicyHolderGender));

            RuleFor(x => x.InsuredState)
                .Must(c => stateRepository.GetState(c) != null).WithMessage("InsuredState is invalid")
                .When(x => !String.IsNullOrWhiteSpace(x.InsuredState));

            RuleFor(c => c.Bin).MaximumLength(50);
            RuleFor(c => c.GroupName).MaximumLength(80);
            RuleFor(c => c.GroupNumber).MaximumLength(50);
            RuleFor(c => c.InsVerifiedBy).MaximumLength(50);
            RuleFor(c => c.InsuredAddress1).MaximumLength(80);
            RuleFor(c => c.InsuredAddress2).MaximumLength(80);
            RuleFor(c => c.InsuredCity).MaximumLength(50);
            RuleFor(c => c.InsuredFirstName).MaximumLength(50);
            RuleFor(c => c.InsuredLastName).MaximumLength(50);
            RuleFor(c => c.InsuredPhone).IsPhoneNumber().MaximumLength(50);
            RuleFor(c => c.InsuredZip).MaximumLength(50);
            RuleFor(c => c.NCDPDPolicyNumber).MaximumLength(50);
            RuleFor(c => c.NCPDPGroupNumber).MaximumLength(50);
            RuleFor(c => c.PayorContact).MaximumLength(80);
            RuleFor(c => c.Pcn).MaximumLength(50);
            RuleFor(c => c.PolicyHolderName).MaximumLength(50);
            RuleFor(c => c.PolicyNumber).MaximumLength(50);
            RuleFor(c => c.VerificationType).MaximumLength(50);
        }
    }
}
