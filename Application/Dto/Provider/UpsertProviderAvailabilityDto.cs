using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class UpsertProviderAvailabilityDto
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        //public bool Deleted { get; set; }
    }

    public class ProviderAvailabilityDtoValidator : AbstractValidator<UpsertProviderAvailabilityDto>
    {
        public ProviderAvailabilityDtoValidator()
        {

            RuleFor(x => x.ProviderID)
              .NotEmpty().WithMessage("ProviderID is required");

            //RuleFor(x => x.DayOfWeek)

            RuleFor(r => r.DayOfWeek)
                .Must(c => Enum.TryParse(c.ToString(), out DayOfWeek dayOfWeek)).WithMessage("Not a valid day of week.");

            RuleFor(r => r.FromTime)
                .NotEmpty()
                .WithMessage("Start Time is Required");

            RuleFor(r => r.ToTime)
                .NotEmpty().WithMessage("End Time is required")
                .Must((obj, c) => obj.FromTime.TimeOfDay < c.TimeOfDay).WithMessage("ToTime must be greater than FromTime");
        }
    }
}
