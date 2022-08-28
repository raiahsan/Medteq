using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFConfigurations
{
    class UserWorkflowStepConfiguration : IEntityTypeConfiguration<UserWorkflowStep>
    {
        public void Configure(EntityTypeBuilder<UserWorkflowStep> entity)
        {
            entity.ToTable("UserWorkflowStep");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserWorkflowSteps)
                .HasForeignKey(d => d.fk_UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWorkflowStep_User");

            entity.HasOne(d => d.WorkflowStep)
                .WithMany(p => p.UserWorkflowSteps)
                .HasForeignKey(d => d.fk_WorkflowStepID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWorkflowStep_WorkflowStep");
        }
    }
}
