﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientAddress : BaseModel
    {
        public int ID { get; set; }
        public int fk_PatientID { get; set; }
        public int fk_AddressTypeID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int fk_StateID { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string ContactPersonName { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual State State { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
