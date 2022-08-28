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
    class WorkflowRecordConfiguration : IEntityTypeConfiguration<WorkflowRecord>
    {
        public void Configure(EntityTypeBuilder<WorkflowRecord> entity)
        {
            entity.ToTable("WorkflowRecord");

            entity.HasOne(d => d.EnterStepUser)
                .WithMany(p => p.WorkflowRecords)
                .HasForeignKey(d => d.EnterStepUserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecord_User");

            entity.HasOne(d => d.Lead)
                .WithMany(p => p.WorkflowRecords)
                .HasForeignKey(d => d.fk_LeadID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecord_Lead");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.WorkflowRecords)
                .HasForeignKey(d => d.fk_PatientID)
                .HasConstraintName("FK_WorkflowRecord_Patient");

            entity.HasOne(d => d.Workflow)
                .WithMany(p => p.WorkflowRecords)
                .HasForeignKey(d => d.fk_WorkflowID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecord_Workflow");

            entity.HasOne(d => d.WorkflowStep)
                .WithMany(p => p.WorkflowRecords)
                .HasForeignKey(d => d.fk_WorkflowStepID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecord_WorkflowStep");
        }
    }
}
