using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class WorkflowState
    {
        public WorkflowState()
        {
            WorkflowRecordStateHistories = new HashSet<WorkflowRecordStateHistory>();
        }

        public int ID { get; set; }
        public string WorkflowStateName { get; set; }
        public bool Closed { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<WorkflowRecordStateHistory> WorkflowRecordStateHistories { get; set; }
    }
}
