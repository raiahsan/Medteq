﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify
{
    public class ServiceCode
    {
        public static readonly string MedicalCare = "1";
        public static readonly string Surgical = "2";
        public static readonly string Consultation = "3";
        public static readonly string DiagnosticXRay = "4";
        public static readonly string DiagnosticLab = "5";
        public static readonly string RadiationTherapy = "6";
        public static readonly string Anesthesia = "7";
        public static readonly string SurgicalAssistance = "8";
        public static readonly string OtherMedical = "9";
        public static readonly string BloodCharges = "10";
        public static readonly string UsedDurableMedicalEquipment = "11";
        public static readonly string DurableMedicalEquipmentPurchase = "12";
        public static readonly string AmbulatoryServiceCenterFacility = "13";
        public static readonly string RenalSuppliesInTheHome = "14";
        public static readonly string AlternateMethodDialysis = "15";
        public static readonly string ChronicRenalDisease_CRD_Equipment = "16";
        public static readonly string PreAdmissionTesting = "17";
        public static readonly string DurableMedicalEquipmentRental = "18";
        public static readonly string PneumoniaVaccine = "19";
        public static readonly string SecondSurgicalOpinion = "20";
        public static readonly string ThirdSurgicalOpinion = "21";
        public static readonly string SocialWork = "22";
        public static readonly string DiagnosticDental = "23";
        public static readonly string Periodontics = "24";
        public static readonly string Restorative = "25";
        public static readonly string Endodontics = "26";
        public static readonly string MaxillofacialProsthetics = "27";
        public static readonly string AdjunctiveDentalServices = "28";
        public static readonly string HealthBenefitPlanCoverage = "30";
        public static readonly string PlanWaitingPeriod = "32";
        public static readonly string Chiropractic = "33";
        public static readonly string ChiropracticOfficeVisits = "34";
        public static readonly string DentalCare = "35";
        public static readonly string DentalCrowns = "36";
        public static readonly string DentalAccident = "37";
        public static readonly string Orthodontics = "38";
        public static readonly string Prosthodontics = "39";
        public static readonly string OralSurgery = "40";
        public static readonly string Routine_Preventive_Dental = "41";
        public static readonly string HomeHealthCare = "42";
        public static readonly string HomeHealthPrescriptions = "43";
        public static readonly string HomeHealthVisits = "44";
        public static readonly string Hospice = "45";
        public static readonly string RespiteCare = "46";
        public static readonly string Hospital = "47";
        public static readonly string HospitalInpatient = "48";
        public static readonly string HospitalRoomAndBoard = "49";
        public static readonly string HospitalOutpatient = "50";
        public static readonly string HospitalEmergencyAccident = "51";
        public static readonly string HospitalEmergencyMedical = "52";
        public static readonly string HospitalAmbulatorySurgical = "53";
        public static readonly string LongTermCare = "54";
        public static readonly string MajorMedical = "55";
        public static readonly string MedicallyRelatedTransportation = "56";
        public static readonly string AirTransportation = "57";
        public static readonly string Cabulance = "58";
        public static readonly string LicensedAmbulanceLicensedAmbulance = "59";
        public static readonly string GeneralBenefits = "60";
        public static readonly string InvitroFertilization = "61";
        public static readonly string MRI_CATScan = "62";
        public static readonly string DonorProcedures = "63";
        public static readonly string Acupuncture = "64";
        public static readonly string NewbornCare = "65";
        public static readonly string Pathology = "66";
        public static readonly string SmokingCessation = "67";
        public static readonly string WellBabyCare = "68";
        public static readonly string Maternity = "69";
        public static readonly string Transplants = "70";
        public static readonly string AudiologyExam = "71";
        public static readonly string InhalationTherapy = "72";
        public static readonly string DiagnosticMedical = "73";
        public static readonly string PrivateDutyNursing = "74";
        public static readonly string ProstheticDevice = "75";
        public static readonly string Dialysis = "76";
        public static readonly string OtologicalExam = "77";
        public static readonly string Chemotherapy = "78";
        public static readonly string AllergyTesting = "79";
        public static readonly string Immunizations = "80";
        public static readonly string RoutinePhysical = "81";
        public static readonly string FamilyPlanning = "82";
        public static readonly string Infertility = "83";
        public static readonly string Abortion = "84";
        public static readonly string AIDS = "85";
        public static readonly string EmergencyServices = "86";
        public static readonly string Cancer = "87";
        public static readonly string Pharmacy = "88";
        public static readonly string FreeStandingPrescriptionDrug = "89";
        public static readonly string MailOrderPrescriptionDrug = "90";
        public static readonly string BrandNamePrescriptionDrug = "91";
        public static readonly string GenericPrescriptionDrug = "92";
        public static readonly string Podiatry = "93";
        public static readonly string Podiatry_OfficeVisits = "94";
        public static readonly string Podiatry_NursingHomeVisits = "95";
        public static readonly string Professional_Physician = "96";
        public static readonly string Anesthesiologist = "97";
        public static readonly string Professional_Physician_VisitOffice = "98";
        public static readonly string Professional_Physician_VisitInpatient = "99";
        public static readonly string Professional_Physician_Visit_Outpatient = "A0";
        public static readonly string Professional_Physician_Visit_Nursing_Home = "A1";
        public static readonly string Professional_Physician_Visit_SkilledNursingFacility = "A2";
        public static readonly string Professional_Physician_Visit_Home = "A3";
        public static readonly string Psychiatric = "A4";
        public static readonly string Psychiatric_RoomAndBoard = "A5";
        public static readonly string Psychotherapy = "A6";
        public static readonly string Psychiatric_Inpatient = "A7";
        public static readonly string Psychiatric_Outpatient = "A8";
        public static readonly string Rehabilitation = "A9";
        public static readonly string Rehabilitation_RoomAndBoard = "AA";
        public static readonly string Rehabilitation_Inpatient = "AB";
        public static readonly string Rehabilitation_Outpatient = "AC";
        public static readonly string OccupationalTherapy = "AD";
        public static readonly string PhysicalMedicine = "AE";
        public static readonly string SpeechTherapy = "AF";
        public static readonly string SkilledNursingCare = "AG";
        public static readonly string SkilledNursingCare_RoomAndBoard = "AH";
        public static readonly string SubstanceAbuse = "AI";
        public static readonly string Alcoholism = "AJ";
        public static readonly string DrugAddiction = "AK";
        public static readonly string Vision_Optometry = "AL";
        public static readonly string Frames = "AM";
        public static readonly string RoutineExam = "AN";
        public static readonly string Lenses = "AO";
        public static readonly string NonmedicallyNecessaryPhysical = "AQ";
        public static readonly string ExperimentalDrugTherapy = "AR";
        public static readonly string BurnCare = "B1";
        public static readonly string BranNamePrescriptionDrug_Formulary = "B2";
        public static readonly string BranNamePrescriptionDrug_Non_Formulary = "B3";
        public static readonly string IndependentMedicalEvaluation = "BA";
        public static readonly string PartialHospitalization_Psychiatric = "BB";
        public static readonly string DayCare_Psychiatric = "BC";
        public static readonly string CognitiveTherapy = "BD";
        public static readonly string MassageTherapy = "BE";
        public static readonly string PulmonaryRehabilitation = "BF";
        public static readonly string CardiacRehabilitation = "BG";
        public static readonly string Pediatric = "BH";
        public static readonly string Nursery = "BI";
        public static readonly string Skin = "BJ";
        public static readonly string Orthopedic = "BK";
        public static readonly string Cardiac = "BL";
        public static readonly string Lymphatic = "BM";
        public static readonly string Gastrointestinal = "BN";
        public static readonly string Endocrine = "BP";
        public static readonly string Neurology = "BQ";
        public static readonly string Eye = "BR";
        public static readonly string InvasiveProcedures = "BS";
        public static readonly string Gynecological = "BT";
        public static readonly string Obsterical = "BU";
        public static readonly string Obsterical_Gynecological = "BV";
        public static readonly string MailOrderPrescriptionDrug_BrandName = "BW";
        public static readonly string MailOrderPrescriptionDrugGeneric = "BX";
        public static readonly string PhysicianVisit_Office_Sick = "BY";
        public static readonly string PhysicianVisit_Office_Well = "BZ";
        public static readonly string CoronaryCare = "C1";
        public static readonly string PrivateDutyNursing_Inpatient = "CA";
        public static readonly string PrivateDutyNursing_Home = "CB";
        public static readonly string SurgicalBenefits_professional_physician = "CC";
        public static readonly string SurgicalBenefits_Facility = "CD";
        public static readonly string MentalHealthProvider_Inpatient = "CE";
        public static readonly string MentalHealthProvider_Outpatient = "CF";
        public static readonly string MentalHealthFacility_Inpatient = "CG";
        public static readonly string MentalHealthFacility_Outpatient = "CH";
        public static readonly string SubstanceAbuseFacility_Inpatient = "CI";
        public static readonly string SubstanceAbuseFacility_Outpatient = "CJ";
        public static readonly string ScreeningX_Ray = "CK";
        public static readonly string ScreeningLaboratory = "CL";
        public static readonly string MammomogramHighRiskPatient = "CM";
        public static readonly string MammomogramLowRiskPatient = "CN";
        public static readonly string FluVaccination = "CO";
        public static readonly string EyewearAndEywearAccessories = "CP";
        public static readonly string CaseManagement = "CQ";
        public static readonly string Dermatology = "DG";
        public static readonly string DurableMedicalEquipment = "DM";
        public static readonly string DiabeticSupplies = "DS";
        public static readonly string GenericPresciptionDrug_Formulary = "GF";
        public static readonly string GenericPresciptionDrug_Non_Formulary = "GN";
        public static readonly string Allergy = "GY";
        public static readonly string IntesiveCare = "IC";
        public static readonly string MentalHealth = "MH";
        public static readonly string NeonatalIntesiveCare = "NI";
        public static readonly string Oncology = "ON";
        public static readonly string PhysicalTherapy = "PT";
        public static readonly string Pulmonary = "PU";
        public static readonly string Renal = "RN";
        public static readonly string ResidentialPsychiatricTreatment = "RT";
        public static readonly string TransitionalCare = "TC";
        public static readonly string TransitionalNurseryCare = "TN";
        public static readonly string UrgentCare = "UC";
    }
}
