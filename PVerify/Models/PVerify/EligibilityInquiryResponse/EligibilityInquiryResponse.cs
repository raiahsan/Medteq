using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilityInquiryResponse
{
    public class EligibilityPeriod
    {
        public object Label { get; set; }
        public string EffectiveFromDate { get; set; }
        public string ExpiredOnDate { get; set; }
    }

    public class Identification
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public object Name { get; set; }
    }

    public class Subscriber
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public object CommunicationNumber { get; set; }
        public object Date { get; set; }
        [JsonProperty("doB_R")]
        public string DOB { get; set; }
        public string Firstname { get; set; }
        [JsonProperty("gender_R")]
        public string Gender { get; set; }
        public List<Identification> Identification { get; set; }
        [JsonProperty("lastname_R")]
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string State { get; set; }
        public object Suffix { get; set; }
        public string Zip { get; set; }
        public object MilitaryPersonnelInfo { get; set; }
        public string FullName { get; set; }
    }

    public class DemographicInfo
    {
        public Subscriber Subscriber { get; set; }
        public object Dependent { get; set; }
    }

    public class InNetworkParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public object Message { get; set; }
        public object OtherInfo { get; set; }
    }

    public class OutNetworkParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public object Message { get; set; }
        public object OtherInfo { get; set; }
    }

    public class NetworkSection
    {
        public string Identifier { get; set; }
        public string Label { get; set; }
        public List<InNetworkParameter> InNetworkParameters { get; set; }
        public List<OutNetworkParameter> OutNetworkParameters { get; set; }
    }

    public class ServiceParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public object Message { get; set; }
        public object OtherInfo { get; set; }
    }

    public class ServiceTypeSection
    {
        public string Label { get; set; }
        public List<ServiceParameter> ServiceParameters { get; set; }
    }

    public class HealthBenefitPlanCoverageServiceType
    {
        public string ServiceTypeName { get; set; }
        public List<ServiceTypeSection> ServiceTypeSections { get; set; }
    }

    public class OtherInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public object Message { get; set; }
        [JsonProperty("otherInfo")]
        public object OtherInformation { get; set; }
    }

    public class ServicesType
    {
        public string ServiceTypeName { get; set; }
        public List<ServiceTypeSection> ServiceTypeSections { get; set; }
    }

    public class ExtensionProperties
    {
        public string PayerCode { get; set; }
        public int PayerID { get; set; }
        public object ResultReport { get; set; }
        public object VerifiedOn { get; set; }
        public object VerifiedBy { get; set; }
    }

    public class EligibilityInquiryResponse
    {
        public int ElgRequestID { get; set; }
        public object EdiErrorMessage { get; set; }
        public string VerificationStatus { get; set; }
        public object VerificationMessage { get; set; }
        public string IsPayerBackOffice { get; set; }
        public string Status { get; set; }
        public string PayerName { get; set; }
        public string VerificationType { get; set; }
        public bool ProcessedWithError { get; set; }
        public string Dos { get; set; }
        public string Plan { get; set; }
        public bool IsHMOPlan { get; set; }
        public string ExceptionNotes { get; set; }
        public string AdditionalInformation { get; set; }
        public object OtherMessage { get; set; }
        public string ReportURL { get; set; }
        public int RecursiveRequestId { get; set; }
        public object RecursiveAPIResponseCode { get; set; }
        public object RecursiveAPIResponseMessage { get; set; }
        public bool RecursiveProcessedWithError { get; set; }
        public object DetailsURL { get; set; }
        public object InternalId { get; set; }
        public object CustomerId { get; set; }
        public object ReferenceId { get; set; }
        public object Notes { get; set; }
        public object Location { get; set; }
        public EligibilityPeriod EligibilityPeriod { get; set; }
        public DemographicInfo DemographicInfo { get; set; }
        public List<NetworkSection> NetworkSections { get; set; }
        public HealthBenefitPlanCoverageServiceType HealthBenefitPlanCoverageServiceType { get; set; }
        public List<ServicesType> ServicesTypes { get; set; }
        public object CustomFields { get; set; }
        public ExtensionProperties ExtensionProperties { get; set; }
        public int VerificationStatusCode { get; set; }
        public object ResponseText { get; set; }
        public object NonEDIResultPath { get; set; }
    }
}
