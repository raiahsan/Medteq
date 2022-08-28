using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilitySummaryResponse
{
    public class DateObject
    {
        public string Date { get; set; }

        public string Type { get; set; }
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
        public object Address2 { get; set; }
        public string City { get; set; }
        public object CommunicationNumber { get; set; }
        public List<DateObject> Date { get; set; }
        public string DOBR { get; set; }
        public string Firstname { get; set; }
        [JsonProperty("Gender_R")]
        public string Gender { get; set; }
        public List<Identification> Identification { get; set; }
        [JsonProperty("Lastname_R")]
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

    public class OtherPayerInfo
    {
        public object PrimaryPayer { get; set; }
        public string Payer { get; set; }
        public object SecondaryPayer { get; set; }
        public object PlanSponsor { get; set; }
        [JsonProperty("IndependentPhysiciansAssociation_IPA")]
        public object IndependentPhysiciansAssociationIPA { get; set; }
        public object WorkersCompensation { get; set; }
        public object ContractedServiceProvider { get; set; }
        public object IPAStartDate { get; set; }
        public object OtherPayerMemberID { get; set; }
        [JsonProperty("COB_StartDate")]
        public object COBStartDate { get; set; }
        [JsonProperty("COB_EndDate")]
        public object COBEndDate { get; set; }
    }

    public class PlanCoverageSummary
    {
        public string Status { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpiryDate { get; set; }
        public string PlanName { get; set; }
        public string PolicyType { get; set; }
        public string GroupNumber { get; set; }
        public object GroupName { get; set; }
        public object PlanNetworkID { get; set; }
        public object PlanNetworkName { get; set; }
        public object SubscriberRelationship { get; set; }
        public string PlanNumber { get; set; }
        public object HRAorHSALimitationsRemaining { get; set; }
        public object LastUpdatedDateOfEDI { get; set; }
    }

    public class PCPAuthInfoSummary
    {
        public string PrimaryCareProviderName { get; set; }
        public string PrimaryCareProviderPhoneNumber { get; set; }
        public object InNetHBPCAuthorizationInfo { get; set; }
        public object OutNetHBPCAuthorizationInfo { get; set; }
        public object UtilizationManagementOrganizationName { get; set; }
        public object UMOTelephone { get; set; }
        public object CapitationFacilityName { get; set; }
    }

    public class IndividualDeductibleInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualDeductibleOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualDeductibleRemainingInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualDeductibleRemainingOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyDeductibleInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyDeductibleOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyDeductibleRemainingInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyDeductibleRemainingOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualOOPInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualOOPOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualOOPRemainingInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class IndividualOOPRemainingOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyOOPInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyOOPOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyOOPRemainingInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class FamilyOOPRemainingOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class HBPCDeductibleOOPSummary
    {
        public IndividualDeductibleInNet IndividualDeductibleInNet { get; set; }
        public IndividualDeductibleOutNet IndividualDeductibleOutNet { get; set; }
        public IndividualDeductibleRemainingInNet IndividualDeductibleRemainingInNet { get; set; }
        public IndividualDeductibleRemainingOutNet IndividualDeductibleRemainingOutNet { get; set; }
        public FamilyDeductibleInNet FamilyDeductibleInNet { get; set; }
        public FamilyDeductibleOutNet FamilyDeductibleOutNet { get; set; }
        public FamilyDeductibleRemainingInNet FamilyDeductibleRemainingInNet { get; set; }
        public FamilyDeductibleRemainingOutNet FamilyDeductibleRemainingOutNet { get; set; }
        public IndividualOOPInNet IndividualOOPInNet { get; set; }
        public IndividualOOPOutNet IndividualOOPOutNet { get; set; }
        public IndividualOOPRemainingInNet IndividualOOPRemainingInNet { get; set; }
        public IndividualOOPRemainingOutNet IndividualOOPRemainingOutNet { get; set; }
        public FamilyOOPInNet FamilyOOPInNet { get; set; }
        public FamilyOOPOutNet FamilyOOPOutNet { get; set; }
        public FamilyOOPRemainingInNet FamilyOOPRemainingInNet { get; set; }
        public FamilyOOPRemainingOutNet FamilyOOPRemainingOutNet { get; set; }
    }

    public class MiscellaneousInfoSummary
    {
        public object RemainingSpendDown { get; set; }
        public object IsNPIInNetwork { get; set; }
        public object MemberID { get; set; }
    }

    public class CoPayInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class CoInsInNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class CoPayOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class CoInsOutNet
    {
        public string Value { get; set; }
        public object Notes { get; set; }
    }

    public class DMESummary
    {
        public CoPayInNet CoPayInNet { get; set; }
        public CoInsInNet CoInsInNet { get; set; }
        public CoPayOutNet CoPayOutNet { get; set; }
        public CoInsOutNet CoInsOutNet { get; set; }
        public object UMOName { get; set; }
        public object UMOTelephone { get; set; }
        public object InNetServiceAuthorizationInfo { get; set; }
        public object OutNetServiceAuthorizationInfo { get; set; }
        public object IndividualDeductibleInNet { get; set; }
        public object IndividualDeductibleOutNet { get; set; }
        public object IndividualDeductibleRemainingInNet { get; set; }
        public object IndividualDeductibleRemainingOutNet { get; set; }
        public object FamilyDeductibleInNet { get; set; }
        public object FamilyDeductibleOutNet { get; set; }
        public object FamilyDeductibleRemainingInNet { get; set; }
        public object FamilyDeductibleRemainingOutNet { get; set; }
        public object IndividualOOPInNet { get; set; }
        public object IndividualOOPOutNet { get; set; }
        public object IndividualOOPRemainingInNet { get; set; }
        public object IndividualOOPRemainingOutNet { get; set; }
        public object FamilyOOPInNet { get; set; }
        public object FamilyOOPOutNet { get; set; }
        public object FamilyOOPRemainingInNet { get; set; }
        public object FamilyOOPRemainingOutNet { get; set; }
    }

    public class CommunicationNumber
    {
        public string Number { get; set; }
        public string Type { get; set; }
    }

    public class BenefitEntity
    {
        public string Address1 { get; set; }
        public object Address2 { get; set; }
        public string City { get; set; }
        public List<CommunicationNumber> CommunicationNumber { get; set; }
        public string EntityType { get; set; }
        public string Firstname { get; set; }
        public string IdentificationCode { get; set; }
        public string IdentificationType { get; set; }
        [JsonProperty("Lastname_R")]
        public string LastnameR { get; set; }
        public object Middlename { get; set; }
        public string State { get; set; }
        public object Suffix { get; set; }
        public string Zip { get; set; }
        public object ProviderTaxonomy { get; set; }
    }

    public class EligibilityDetail
    {
        public object AuthorizationOrCertificationRequired { get; set; }
        public string EligibilityOrBenefit { get; set; }
        public string CoverageLevel { get; set; }
        public List<object> Date { get; set; }
        public List<object> Identifications { get; set; }
        public string InsuranceType { get; set; }
        public List<string> Message { get; set; }
        public string MonetaryAmount { get; set; }
        public string Percent { get; set; }
        public string PlanCoverageDescription { get; set; }
        public string PlanNetworkIndicator { get; set; }
        public object QuantityQualifier { get; set; }
        public object Quantity { get; set; }
        public string TimePeriodQualifier { get; set; }
        public object Procedure { get; set; }
        public object PlaceOfService { get; set; }
        public List<BenefitEntity> BenefitEntities { get; set; }
        public List<object> HealthCareServiceDeliveries { get; set; }
    }

    public class ServiceDetail
    {
        public string ServiceName { get; set; }
        public List<EligibilityDetail> EligibilityDetails { get; set; }
    }

    public class EligibilitySummaryResponse
    {
        public int RequestID { get; set; }
        public string APIResponseCode { get; set; }
        public string APIResponseMessage { get; set; }
        public object EDIErrorMessage { get; set; }
        public bool IsPayerBackOffice { get; set; }
        public bool ProcessedWithError { get; set; }
        public string PverifyPayerCode { get; set; }
        public string PayerName { get; set; }
        public string VerificationType { get; set; }
        public string DOS { get; set; }
        public object ExceptionNotes { get; set; }
        public bool IsHMOPlan { get; set; }
        public object AddtionalInfo { get; set; }
        public string Location { get; set; }
        public object ReferrenceId { get; set; }
        public string ResultPracticeType { get; set; }
        public int RecursiveRequestId { get; set; }
        public object RecursiveAPIResponseCode { get; set; }
        public object RecursiveAPIResponseMessage { get; set; }
        public bool RecursiveProcessedWithError { get; set; }
        public object IsPriorAuthRequired { get; set; }
        public string DetailsURL { get; set; }
        public DemographicInfo DemographicInfo { get; set; }
        public OtherPayerInfo OtherPayerInfo { get; set; }
        public PlanCoverageSummary PlanCoverageSummary { get; set; }
        public PCPAuthInfoSummary PCPAuthInfoSummary { get; set; }
        [JsonProperty("HBPC_Deductible_OOP_Summary")]
        public HBPCDeductibleOOPSummary HBPCDeductibleOOPSummary { get; set; }
        public object MedicareInfoSummary { get; set; }
        public MiscellaneousInfoSummary MiscellaneousInfoSummary { get; set; }
        public DMESummary DMESummary { get; set; }
        public object DisclaimerMessage { get; set; }
        public List<ServiceDetail> ServiceDetails { get; set; }
        public object PreventiveServices { get; set; }
        public object EligibilityResult { get; set; }
        public object NonEDIResultPath { get; set; }
    }


}
