using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Workflow
    {
        public Workflow()
        {
            WorkflowRecords = new HashSet<WorkflowRecord>();
            WorkflowSteps = new HashSet<WorkflowStep>();
        }

        public int ID { get; set; }
        public string WorkflowName { get; set; }
        public string WorkflowDescription { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<WorkflowRecord> WorkflowRecords { get; set; }
        public virtual ICollection<WorkflowStep> WorkflowSteps { get; set; }
    }
}
