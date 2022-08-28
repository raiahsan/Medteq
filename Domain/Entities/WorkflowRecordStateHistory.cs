using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class WorkflowRecordStateHistory
    {
        public int ID { get; set; }
        public int fk_WorkflowRecordID { get; set; }
        public int fk_WorkflowStateID { get; set; }
        public DateTime EnterStateTime { get; set; }
        public int EnteredStateByUserId { get; set; }

        public virtual User EnteredStateByUser { get; set; }
        public virtual WorkflowRecord WorkflowRecord { get; set; }
        public virtual WorkflowState WorkflowState { get; set; }
    }
}
