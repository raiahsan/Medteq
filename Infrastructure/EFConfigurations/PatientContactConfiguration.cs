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
    class PatientContactConfiguration : IEntityTypeConfiguration<PatientContact>
    {
        public void Configure(EntityTypeBuilder<PatientContact> entity)
        {
            entity.ToTable("PatientContact");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MobileNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.PatientContactsCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientContact_User");

            entity.HasOne(d => d.ContactType)
                .WithMany(p => p.PatientContacts)
                .HasForeignKey(d => d.fk_ContactTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientContact_ContactType");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.PatientContacts)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientContact_Patient");

            entity.HasOne(d => d.RelationshipType)
                .WithMany(p => p.PatientContacts)
                .HasForeignKey(d => d.fk_RelationshipTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientContact_RelationshipType");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.PatientContactsModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientContact_User1");

            entity.HasOne(d => d.State)
                .WithMany(p => p.PatientContacts)
                .HasForeignKey(d => d.fk_StateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientContact_State");
        }
    }
}
