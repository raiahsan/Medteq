using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class WorkflowStepHistory
    {
        public int ID { get; set; }
        public int fk_WorkflowRecordID { get; set; }
        public int fk_WorkflowStepID { get; set; }
        public DateTime EnterStepTime { get; set; }
        public int EnterStepUserID { get; set; }
        public DateTime ExitStepTime { get; set; }
        public int ExitStepUserID { get; set; }
        public bool Completed { get; set; }
        public string StepNotes { get; set; }

        public virtual User EnterStepUser { get; set; }
        public virtual User ExitStepUser { get; set; }
        public virtual WorkflowRecord WorkflowRecord { get; set; }
        public virtual WorkflowStep WorkflowStep { get; set; }
    }
}
