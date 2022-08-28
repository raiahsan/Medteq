using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class WorkflowStep
    {
        public WorkflowStep()
        {
            InverseRegressToStep = new HashSet<WorkflowStep>();
            UserWorkflowSteps = new HashSet<UserWorkflowStep>();
            WorkflowRecordNotes = new HashSet<WorkflowRecordNote>();
            WorkflowRecords = new HashSet<WorkflowRecord>();
            WorkflowStepHistories = new HashSet<WorkflowStepHistory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string LabelAlias { get; set; }
        public int fk_WorkflowID { get; set; }
        public int WorkflowSequence { get; set; }
        public int? DashboardSequence { get; set; }
        public bool Active { get; set; }
        public bool FinalStep { get; set; }
        public int RegressToStepID { get; set; }

        public virtual Workflow Workflow { get; set; }
        public virtual WorkflowStep RegressToStep { get; set; }
        public virtual ICollection<WorkflowStep> InverseRegressToStep { get; set; }
        public virtual ICollection<UserWorkflowStep> UserWorkflowSteps { get; set; }
        public virtual ICollection<WorkflowRecordNote> WorkflowRecordNotes { get; set; }
        public virtual ICollection<WorkflowRecord> WorkflowRecords { get; set; }
        public virtual ICollection<WorkflowStepHistory> WorkflowStepHistories { get; set; }
    }
}
