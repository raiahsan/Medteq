using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HL7.Models
{
    public class MessageTypes
    {
        public const string ADT_Admit_Discharge_Transfer = "ADT";
        public const string SIU_Schedule_Information_Unsolicited = "SIU";
        public const string DFT_Detailed_Financial_Transactions = "DFT";
    }

    public class TriggerTypes
    {
        public const string ADT04_Register_Patient = "A04";
        public const string ADT08_Update_Patient_Information = "A08";
        public const string S12_Notification_New_Appointment_Booking = "S12";
        public const string S13_Notification_Appointment_Rescheduling = "S13";
        public const string S14_Notification_Appointment_Modification = "S14";
        public const string S15_Notification_Appointment_Cancellation = "S15";
        public const string P03_Post_Detail_Financial_Transaction = "S15";
    }
    public class MessageStructureTypes
    {
        public const string ADT04_Register_Patient = "ADT_A01";
        public const string ADT08_Update_Patient_Information = "ADT_A01";
        public const string S12_Notification_New_Appointment_Booking = "SIIU_S12";
        public const string S13_Notification_Appointment_Rescheduling = "SIIU_S12";
        public const string S14_Notification_Appointment_Modification = "SIIU_S12";
        public const string S15_Notification_Appointment_Cancellation = "SIIU_S12";
        public const string P03_Post_Detail_Financial_Transaction = "DFT_P03";
    }
    public class ProcessingIdTypes
    {
        public const string Debugging = "D";
        public const string Production = "P";
        public const string Training = "T";
    }
    public class VersionTypes
    {
        public const string Version_2_3 = "2.3";
        public const string Version_2_3_1 = "2.3.1";
        public const string Version_2_5_1 = "2.5.1";
    }
}
