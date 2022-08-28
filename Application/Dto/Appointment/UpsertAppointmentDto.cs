using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Appointment
{
    public class UpsertAppointmentDto
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public int PatientID { get; set; }
        public DateTime BookingStartDateTime { get; set; }
        public DateTime BookingEndDateTime { get; set; }
        public string Notes { get; set; }
    }
    public class UpsertAppointmentDtoValidator : AbstractValidator<UpsertAppointmentDto>
    {
        public UpsertAppointmentDtoValidator()
        {

            RuleFor(x => x.ProviderID)
              .NotEmpty().WithMessage("ProviderID is required");

            RuleFor(x => x.PatientID)
              .NotEmpty().WithMessage("PatientID is required");

            RuleFor(r => r.BookingStartDateTime)
                .NotEmpty().WithMessage("BookingStartDateTime is required");

            RuleFor(r => r.BookingEndDateTime)
                .NotEmpty().WithMessage("BookingEndDateTime is required")
                .GreaterThan(r => r.BookingStartDateTime).WithMessage("BookingEndDateTime must Greater than BookingStartDateTime");
        }
    }
}
