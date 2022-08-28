using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class UpsertProviderUnvailabilityDto
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
       // public bool Deleted { get; set; }
    }

    public class ProviderUnavailabilityDtoValidator : AbstractValidator<UpsertProviderUnvailabilityDto>
    {
        public ProviderUnavailabilityDtoValidator()
        {
            RuleFor(x => x.ProviderID)
              .NotEmpty().WithMessage("ProviderID is required");

            RuleFor(r => r.FromDateTime)
                .NotEmpty()
                .WithMessage("Start Time is Required");

            RuleFor(r => r.ToDateTime)
                .NotEmpty().WithMessage("End Time is required")
                .GreaterThan(r => r.FromDateTime).WithMessage("End Time must Greater than Start time");
        }
    }
}
