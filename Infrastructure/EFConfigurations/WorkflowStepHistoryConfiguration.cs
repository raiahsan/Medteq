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
    class WorkflowStepHistoryConfiguration : IEntityTypeConfiguration<WorkflowStepHistory>
    {
        public void Configure(EntityTypeBuilder<WorkflowStepHistory> entity)
        {
            entity.ToTable("WorkflowStepHistory");

            entity.Property(e => e.ExitStepTime).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.StepNotes)
                .HasMaxLength(1500)
                .IsUnicode(false);

            entity.HasOne(d => d.EnterStepUser)
                .WithMany(p => p.WorkflowStepHistoryEnterStepUsers)
                .HasForeignKey(d => d.EnterStepUserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowStepHistory_User");

            entity.HasOne(d => d.ExitStepUser)
                .WithMany(p => p.WorkflowStepHistoryExitStepUsers)
                .HasForeignKey(d => d.ExitStepUserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowStepHistory_User1");

            entity.HasOne(d => d.WorkflowRecord)
                .WithMany(p => p.WorkflowStepHistories)
                .HasForeignKey(d => d.fk_WorkflowRecordID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowStepHistory_WorkflowRecord");

            entity.HasOne(d => d.WorkflowStep)
                .WithMany(p => p.WorkflowStepHistories)
                .HasForeignKey(d => d.fk_WorkflowStepID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowStepHistory_WorkflowStep");
        }
    }
}
