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
    class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> entity)
        {
            entity.ToTable("Patient");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.DateOfAdmission).HasColumnType("date");

            entity.Property(e => e.DateOfDischarge).HasColumnType("date");

            entity.Property(e => e.DateOfOnset).HasColumnType("date");

            entity.Property(e => e.DOB)
                .HasColumnType("date");

            entity.Property(e => e.DOD)
                .HasColumnType("date");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.EmailVerifiedDate).HasColumnType("datetime");

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Height)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.HippasignatureOnFile).HasColumnName("HIPPASignatureOnFile");

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.MobileVerifiedDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.SSN)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.StateOfAutoAccident)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Suffix)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Weight)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.PatientsCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_User");

            entity.HasOne(d => d.Branch)
                .WithMany(p => p.Patients)
                .HasForeignKey(d => d.fk_BranchID)
                .HasConstraintName("FK_Patient_Branch");

            entity.HasOne(d => d.Gender)
                .WithMany(p => p.Patients)
                .HasForeignKey(d => d.fk_GenderID)
                .HasConstraintName("FK_Patient_Gender");

            entity.HasOne(d => d.LinkedPatient)
                .WithMany(p => p.LinkedPatients)
                .HasForeignKey(d => d.fk_LinkedPatientID)
                .HasConstraintName("FK_Patient_Patient");

            entity.HasOne(d => d.MaritalStatus)
                .WithMany(p => p.Patients)
                .HasForeignKey(d => d.fk_MaritalStatusID)
                .HasConstraintName("FK_Patient_MaritalStatus");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.PatientsModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_User1");
        }
    }
}
