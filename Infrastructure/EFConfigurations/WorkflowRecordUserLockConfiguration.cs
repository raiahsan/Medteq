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
    class WorkflowRecordUserLockConfiguration : IEntityTypeConfiguration<WorkflowRecordUserLock>
    {
        public void Configure(EntityTypeBuilder<WorkflowRecordUserLock> entity)
        {
            entity.ToTable("WorkflowRecordUserLock");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User)
                .WithMany(p => p.WorkflowRecordUserLocks)
                .HasForeignKey(d => d.fk_UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordUserLock_User");

            entity.HasOne(d => d.WorkflowRecord)
                .WithMany(p => p.WorkflowRecordUserLocks)
                .HasForeignKey(d => d.fk_WorkflowRecordID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordUserLock_WorkflowRecord");
        }
    }
}
