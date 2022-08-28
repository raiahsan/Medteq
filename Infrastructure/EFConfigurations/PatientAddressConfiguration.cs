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
    class PatientAddressConfiguration : IEntityTypeConfiguration<PatientAddress>
    {
        public void Configure(EntityTypeBuilder<PatientAddress> entity)
        {
            entity.ToTable("PatientAddress");

            entity.Property(e => e.AddressLine1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.AddressLine2)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ContactPersonName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.MobileNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AddressType)
                .WithMany(p => p.PatientAddresses)
                .HasForeignKey(d => d.fk_AddressTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAddress_AddressType");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.PatientAddresses)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAddress_Patient");

            entity.HasOne(d => d.State)
                .WithMany(p => p.PatientAddresses)
                .HasForeignKey(d => d.fk_StateID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PatientAddress_State");
        }
    }
}
