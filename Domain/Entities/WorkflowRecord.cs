using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class WorkflowRecord
    {
        public WorkflowRecord()
        {
            WorkflowRecordNotes = new HashSet<WorkflowRecordNote>();
            WorkflowRecordStateHistories = new HashSet<WorkflowRecordStateHistory>();
            WorkflowRecordUserLocks = new HashSet<WorkflowRecordUserLock>();
            WorkflowStepHistories = new HashSet<WorkflowStepHistory>();
        }

        public int ID { get; set; }
        public int fk_WorkflowID { get; set; }
        public int fk_LeadID { get; set; }
        public int? fk_PatientID { get; set; }
        public int fk_WorkflowStepID { get; set; }
        public int ReturnToStepID { get; set; }
        public int EnterStepUserID { get; set; }
        public DateTime EnterStepTime { get; set; }
        public bool Active { get; set; }

        public virtual User EnterStepUser { get; set; }
        public virtual Lead Lead { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Workflow Workflow { get; set; }
        public virtual WorkflowStep WorkflowStep { get; set; }
        public virtual ICollection<WorkflowRecordNote> WorkflowRecordNotes { get; set; }
        public virtual ICollection<WorkflowRecordStateHistory> WorkflowRecordStateHistories { get; set; }
        public virtual ICollection<WorkflowRecordUserLock> WorkflowRecordUserLocks { get; set; }
        public virtual ICollection<WorkflowStepHistory> WorkflowStepHistories { get; set; }
    }
}
