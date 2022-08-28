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
    class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> entity)
        {
            entity.ToTable("Lead");

            entity.Property(e => e.BillingAddress1)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BillingAddress2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BillingAddress3)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BillingCity)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BillingPostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.DateLastSeenByDoctor).HasColumnType("date");

            entity.Property(e => e.DOB)
                .HasColumnType("date");

            entity.Property(e => e.DoctorFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DoctorLastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DoctorNPI)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LeadRawData).IsUnicode(false);

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.Notes)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.Branch)
                .WithMany(p => p.Leads)
                .HasForeignKey(d => d.fk_BranchID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lead_Branch");

            entity.HasOne(d => d.Gender)
                .WithMany(p => p.Leads)
                .HasForeignKey(d => d.fk_GenderID)
                .HasConstraintName("FK_Lead_Gender");

            entity.HasOne(d => d.LeadSource)
                .WithMany(p => p.Leads)
                .HasForeignKey(d => d.fk_LeadSourceID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lead_LeadSource");

            entity.HasOne(d => d.LeadType)
                .WithMany(p => p.Leads)
                .HasForeignKey(d => d.fk_LeadTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lead_LeadType");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.Leads)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lead_Patient");

            entity.HasOne(d => d.BillingState)
                .WithMany(p => p.Leads)
                .HasForeignKey(d => d.fk_BillingStateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lead_BillingState");
        }
    }
}
