using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class UserWorkflowStep
    {
        public int ID { get; set; }
        public int fk_UserID { get; set; }
        public int fk_WorkflowStepID { get; set; }

        public virtual User User { get; set; }
        public virtual WorkflowStep WorkflowStep { get; set; }
    }
}
