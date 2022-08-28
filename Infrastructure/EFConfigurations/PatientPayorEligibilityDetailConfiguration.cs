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
    class PatientPayorEligibilityDetailConfiguration : IEntityTypeConfiguration<PatientPayorEligibilityDetail>
    {
        public void Configure(EntityTypeBuilder<PatientPayorEligibilityDetail> entity)
        {
            entity.ToTable("PatientPayorEligibilityDetail");

            entity.HasKey(e => e.EligibilityDetailID);

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.AddressLine2)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.Dob).HasColumnType("date");

            entity.Property(e => e.EligibilityBegin)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.GroupNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MemberID)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Note).IsUnicode(false);

            entity.Property(e => e.OtherInfo).IsUnicode(false);

            entity.Property(e => e.PlanBegin)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PlanNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PlanText)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PlanType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RawJsonData).IsUnicode(false);

            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ReportText).IsUnicode(false);

            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PatientPayorEligiblity)
                .WithMany(p => p.PatientPayorEligibilityDetails)
                .HasForeignKey(d => d.fk_PatientPayorEligiblityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayorEligibilityDetail_PatientPayorEligibility");

            entity.HasOne(d => d.State)
                .WithMany(p => p.PatientPayorEligibilityDetails)
                .HasForeignKey(d => d.fk_StateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayorEligibilityDetail_State");
        }
    }
}
