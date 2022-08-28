using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PatientProvider
{
    public class UpsertPatientProviderDto
    {
        public int PatientID { get; set; }
        public List<Provider_ProviderTypeDto> PatientProviders { get; set; }
    }

    public class UpsertProviderDtoValidator : AbstractValidator<UpsertPatientProviderDto>
    {
        public UpsertProviderDtoValidator()
        {
            RuleFor(x => x.PatientID)
                .NotNull().WithMessage("PatientID is required");      
        }
    }
}
