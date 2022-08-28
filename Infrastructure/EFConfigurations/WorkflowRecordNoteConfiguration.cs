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
    class WorkflowRecordNoteConfiguration : IEntityTypeConfiguration<WorkflowRecordNote>
    {
        public void Configure(EntityTypeBuilder<WorkflowRecordNote> entity)
        {
            entity.ToTable("WorkflowRecordNote");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.WorkflowRecordNotes)
                .HasForeignKey(d => d.fk_UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordNote_User");

            entity.HasOne(d => d.WorkflowRecord)
                .WithMany(p => p.WorkflowRecordNotes)
                .HasForeignKey(d => d.fk_WorkflowRecordID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordNote_WorkflowRecord");

            entity.HasOne(d => d.WorkflowStep)
                .WithMany(p => p.WorkflowRecordNotes)
                .HasForeignKey(d => d.fk_WorkflowStepID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowRecordNote_WorkflowStep");
        }
    }
}
