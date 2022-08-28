using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class WorkflowRecordNote
    {
        public int ID { get; set; }
        public int fk_WorkflowRecordID { get; set; }
        public int fk_WorkflowStepID { get; set; }
        public int fk_UserID { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual WorkflowRecord WorkflowRecord { get; set; }
        public virtual WorkflowStep WorkflowStep { get; set; }
    }
}
