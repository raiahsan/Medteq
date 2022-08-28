using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Provider : BaseModel
    {
        public Provider()
        {
            Appointments = new HashSet<Appointment>();
            ParentProviders = new HashSet<Provider>();
            PatientProviders = new HashSet<PatientProvider>();
            ProviderAvailbilities = new HashSet<ProviderAvailability>();
            ProviderUnavailbilities = new HashSet<ProviderUnavailability>();
        }

        public int ID { get; set; }
        public Guid ProviderHubID { get; set; }
        public int? fk_ParentProviderID { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DoctorGroup { get; set; }
        public string Upin { get; set; }
        public string MedicalID { get; set; }
        public string Deanumber { get; set; }
        public DateTime? DeaexpiryDate { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string StateMedicaidID { get; set; }
        public string NPINumber { get; set; }
        public string CommercialNumber { get; set; }
        public string TaxonomyCode { get; set; }
        public string Specialty { get; set; }
        public string IMSRxerID { get; set; }
        public string Location { get; set; }
        public int? MarketDecile { get; set; }
        public string DegreeDescription { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public virtual Provider ParentProvider { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Provider> ParentProviders { get; set; }
        public virtual ICollection<PatientProvider> PatientProviders { get; set; }
        public virtual ICollection<ProviderAvailability> ProviderAvailbilities { get; set; }
        public virtual ICollection<ProviderUnavailability> ProviderUnavailbilities { get; set; }
    }
}
