using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Appointment : BaseModel
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
        public string RawData { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual User ModifiedByUser { get; set; }
    }
}
