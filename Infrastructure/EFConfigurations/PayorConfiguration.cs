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
    class PayorConfiguration : IEntityTypeConfiguration<Payor>
    {
        public void Configure(EntityTypeBuilder<Payor> entity)
        {
            entity.ToTable("Payor");

            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Bin)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ClaimPercentage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ContactFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ContactLastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ContactMiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayorName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PayorCode)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Pcn)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.PlanType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.PriceTable)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RawData).IsUnicode(false);

            entity.Property(e => e.SiteUrl)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.Submission)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TaxType)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
