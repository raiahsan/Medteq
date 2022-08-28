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
    class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> entity)
        {
            entity.ToTable("Appointment");


            entity.Property(e => e.BookingEndDateTime).HasColumnType("datetime");

            entity.Property(e => e.BookingStartDateTime).HasColumnType("datetime");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.ExternalSystemAppointmentID)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.Notes)
                .HasMaxLength(550)
                .IsUnicode(false);

            entity.Property(e => e.RawData)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.AppointmentsCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_User");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.fk_ProviderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Provider");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.AppointmentsModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_User1");
        }
    }
}
