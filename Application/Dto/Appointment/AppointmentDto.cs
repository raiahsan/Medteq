using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Appointment
{
    public class AppointmentDto
    {
        public int ID { get; set; }
        public int fk_ProviderID { get; set; }
        public int fk_PatientID { get; set; }
        public DateTime? BookingStartDateTime { get; set; }
        public DateTime? BookingEndDateTime { get; set; }
        public decimal? Total { get; set; }
        public bool Approved { get; set; }
        public bool Active { get; set; }
        public string ExternalSystemAppointmentID { get; set; }
        public string Notes { get; set; }
        public bool Cancelled { get; set; }
        public bool Rescheduled { get; set; }
       // public string RawData { get; set; }
    }
}
