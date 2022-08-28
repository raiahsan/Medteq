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
    class ActivityTaskConfiguration : IEntityTypeConfiguration<ActivityTask>
    {
        public void Configure(EntityTypeBuilder<ActivityTask> entity)
        {
            entity.ToTable("ActivityTask");

            entity.Property(e => e.Description)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.Due).HasColumnType("datetime");

            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity)
                .WithMany(p => p.ActivityTasks)
                .HasForeignKey(d => d.fk_ActivityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Activity");

            entity.HasOne(d => d.Status)
                .WithMany(p => p.ActivityTasks)
                .HasForeignKey(d => d.fk_StatusID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_ActivityStatus");
        }
    }
}
