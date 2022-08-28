using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientContact : BaseModel
    {
        public int ID { get; set; }
        public int fk_PatientID { get; set; }
        public int fk_ContactTypeID { get; set; }
        public int fk_RelationshipTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? fk_StateID { get; set; }
        public string PostalCode { get; set; }
        public bool Active { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual State State { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
        public virtual User ModifiedByUser { get; set; }
    }
}
