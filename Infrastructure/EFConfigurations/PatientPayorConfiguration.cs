﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFConfigurations
{
    class PatientPayorConfiguration : IEntityTypeConfiguration<PatientPayor>
    {
        public void Configure(EntityTypeBuilder<PatientPayor> entity)
        {
            entity.ToTable("PatientPayor");

            entity.Property(e => e.Bin)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.Deductible).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.GroupName)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.GroupNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.InsVerifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.InsVerifiedDate).HasColumnType("datetime");

            entity.Property(e => e.InsuredAddress1)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.InsuredAddress2)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.InsuredCity)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.InsuredFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.InsuredLastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.InsuredPhone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.InsuredZip)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.NCDPDPolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NCPDPGroupNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayPercent).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.PayorContact)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Pcn)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PolicyEndDate).HasColumnType("datetime");

            entity.Property(e => e.PolicyHolderDOB)
                .HasColumnType("date");

            entity.Property(e => e.PolicyHolderName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PolicyStartDate).HasColumnType("datetime");

            entity.Property(e => e.RawData)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.VerificationType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.PatientPayors)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayor_Patient");

            entity.HasOne(d => d.Payor)
                .WithMany(p => p.PatientPayors)
                .HasForeignKey(d => d.fk_PayorID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayor_Payor");

            entity.HasOne(d => d.PayorLevel)
                .WithMany(p => p.PatientPayors)
                .HasForeignKey(d => d.fk_PayorLevelID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayor_PayorLevel");

            entity.HasOne(d => d.PolicyHolderGender)
                .WithMany(p => p.PatientPayors)
                .HasForeignKey(d => d.fk_PolicyHolderGenderID)
                .HasConstraintName("FK_PatientPayor_Gender");

            entity.HasOne(d => d.InsuredState)
                .WithMany(p => p.PatientPayors)
                .HasForeignKey(d => d.fk_InsuredStateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayor_State");
        }
    }
}
