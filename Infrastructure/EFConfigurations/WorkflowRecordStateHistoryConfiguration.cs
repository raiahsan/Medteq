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
    class WorkflowRecordStateHistoryConfiguration : IEntityTypeConfiguration<WorkflowRecordStateHistory>
    {
        public void Configure(EntityTypeBuilder<WorkflowRecordStateHistory> entity)
        {
            entity.ToTable("WorkflowRecordStateHistory");

            entity.Property(e => e.EnteredStateByUserId).HasColumnName("EnteredStateByUserID");

            entity.HasOne(d => d.EnteredStateByUser)
                .WithMany(p => p.WorkflowRecordStateHistories)
                .HasForeignKey(d => d.EnteredStateByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordStateHistory_User");

            entity.HasOne(d => d.WorkflowRecord)
                .WithMany(p => p.WorkflowRecordStateHistories)
                .HasForeignKey(d => d.fk_WorkflowRecordID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordStateHistory_WorkflowRecord");

            entity.HasOne(d => d.WorkflowState)
                .WithMany(p => p.WorkflowRecordStateHistories)
                .HasForeignKey(d => d.fk_WorkflowStateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordStateHistory_WorkflowState");
        }
    }
}
