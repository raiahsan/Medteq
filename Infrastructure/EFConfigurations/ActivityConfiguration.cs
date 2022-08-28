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
    class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> entity)
        {
            entity.ToTable("Activity");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.fk_ActivityTypeID);

            entity.Property(e => e.fk_PatientID);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.ActivitiesCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_User");

            entity.HasOne(d => d.ActivityType)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.fk_ActivityTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_ActivityType");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_Patient");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.ActivitiesModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_User1");
        }
    }
}
