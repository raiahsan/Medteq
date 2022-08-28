using Application.CustomValidators;
using Application.RepositoryInterfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Lead
{
    public class GetLeadDto
    {
        public int ID { get; set; }
        public string LeadType { get; set; }
        public string LeadSource { get; set; }
        public string Branch { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string MobilePhone { get; set; }
        public string BillingPostalCode { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorNPI { get; set; }
        public DateTime? DateLastSeenByDoctor { get; set; }
        public int? DiagnosisCode { get; set; }
        public string Notes { get; set; }
        public List<LeadContactDto> LeadContacts { get; set; }
    }
}