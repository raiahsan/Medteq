using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class LeadContact
    {
        public int ID { get; set; }
        public int fk_LeadID { get; set; }
        public int fk_ContactMethodID { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public bool IsDefault { get; set; }

        public virtual ContactMethod ContactMethod { get; set; }
        public virtual Lead Lead { get; set; }
    }
}
