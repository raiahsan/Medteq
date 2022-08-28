using Application.Helper;
using Application.HL7.Models;
using Domain.Entities;
using NHapi.Base.Parser;
using NHapi.Model.V23.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HL7.Version_2_3.ADT_AdmitDischargeTransfer
{
    public class ADT_A04_RegisterPatient : IHL7Parser
    {
        public Patient Decode(string hl7Format)
        {
            PipeParser parser = new PipeParser();
            // Parsing it will return an abstract message
            var m = parser.Parse(hl7Format);
            var type = m.GetType().FullName;
            var patient = new Patient();
            return null;
        }

        public string Encode(Patient patient)
        {
            ADT_A04 request = new ADT_A04();
            request.MSH.FieldSeparator.Value = "|";
            request.MSH.EncodingCharacters.Value = @"^~\&";

            request.MSH.SendingApplication.NamespaceID.Value = "Reporteq";
            request.MSH.SendingApplication.UniversalID.Value = "12321321312";

            request.MSH.SendingFacility.NamespaceID.Value = "";
            //request.MSH.SendingFacility.UniversalID.Value = "";

            request.MSH.ReceivingApplication.NamespaceID.Value = "";
            request.MSH.ReceivingApplication.UniversalID.Value = "";

            request.MSH.ReceivingFacility.NamespaceID.Value = "";
            request.MSH.ReceivingFacility.UniversalID.Value = "";

            request.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(DateTime.UtcNow);
            //request.MSH.Security.Value = "";

            request.MSH.MessageType.MessageType.Value = MessageTypes.ADT_Admit_Discharge_Transfer;
            request.MSH.MessageType.TriggerEvent.Value = TriggerTypes.ADT04_Register_Patient;

            request.MSH.MessageControlID.Value = "";
            request.MSH.ProcessingID.ProcessingID.Value = ProcessingIdTypes.Debugging;
            request.MSH.VersionID.Value = VersionTypes.Version_2_3;

            request.PID.SetIDPatientID.Value = "";
            request.PID.PatientIDExternalID.ID.Value = "12321";

            request.PID.GetPatientIDInternalID(0).ID.Value = "12312312";
            request.PID.GetAlternatePatientID(0).ID.Value = "12312312123132";

            request.PID.GetPatientName(0).GivenName.Value = patient.FirstName;
            request.PID.GetPatientName(0).FamilyName.Value = patient.LastName;

            request.PID.MotherSMaidenName.FamilyName.Value = "";

            request.PID.DateOfBirth.TimeOfAnEvent.SetLongDate(patient.DOB ?? DateTime.UtcNow);
            request.PID.Sex.Value = patient.Gender?.Value.First().ToString();
            for (int i = 0; i < patient.PatientAddresses?.Count; i++)
            {
                request.PID.GetPatientAddress(i).StreetAddress.Value = patient.PatientAddresses.ElementAt(i).AddressLine1;
                request.PID.GetPatientAddress(i).OtherDesignation.Value = patient.PatientAddresses.ElementAt(i).AddressLine2;
                request.PID.GetPatientAddress(i).City.Value = patient.PatientAddresses.ElementAt(i).City;
                request.PID.GetPatientAddress(i).StateOrProvince.Value = patient.PatientAddresses.ElementAt(i).State?.Name;
                request.PID.GetPatientAddress(i).ZipOrPostalCode.Value = patient.PatientAddresses.ElementAt(i).PostalCode;
                request.PID.GetPatientAddress(i).Country.Value = "USA";
            }


            request.PID.GetPhoneNumberHome(0).PhoneNumber.Value = patient.MobilePhone?.ToHL7PhoneNumberFormat();
            request.PID.GetPhoneNumberHome(0).EmailAddress.Value = patient.EmailAddress;


            request.PID.GetPhoneNumberBusiness(0).PhoneNumber.Value = "";
            request.PID.GetPhoneNumberBusiness(0).EmailAddress.Value = "";
            request.PID.GetPhoneNumberBusiness(0).CountryCode.Value = "";
            request.PID.GetPhoneNumberBusiness(0).AreaCityCode.Value = "";
            request.PID.GetPhoneNumberBusiness(0).TelecommunicationUseCode.Value = "";
            request.PID.GetPhoneNumberBusiness(0).TelecommunicationEquipmentType.Value = "";

            request.PID.PrimaryLanguage.Identifier.Value = "EN";
            request.PID.MaritalStatus.Value = "S";
            request.PID.Religion.Value = "";
            //request.PID.PatientAccountNumber.IdentifierTypeCode.Value = "";
            request.PID.SSNNumberPatient.Value = patient.SSN?.ToSSNFormat();
            request.PID.DriverSLicenseNumber.DriverSLicenseNumber.Value = "";
            request.PID.GetMotherSIdentifier(0).ID.Value = "";
            request.PID.EthnicGroup.Value = "";

            PipeParser parser = new PipeParser();
            string result = parser.Encode(request);
            return result;
        }
    }
}
