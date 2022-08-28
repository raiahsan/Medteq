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
    class PatientPayorEligibilityConfiguration : IEntityTypeConfiguration<PatientPayorEligibility>
    {
        public void Configure(EntityTypeBuilder<PatientPayorEligibility> entity)
        {
            entity.ToTable("PatientPayorEligibility");

            entity.HasKey(e => e.EligibilityID);

            entity.Property(e => e.BatchName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.DateOfServiceFrom)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DateOfServiceTo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DependentFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DependentLastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DependentRelationship)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.EligibilityRequestData)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.EligiblityRawResponse)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.IssueDate)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.Notes)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.PatientDOB)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PatientGender)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ProviderFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ProviderLastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ProviderNPI)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ProviderPIN)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ProviderTaxanomy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ServiceCodes)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SubcriberFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SubcriberLastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SubcriberMemberID)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SubcriberSSN)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SubscriberGroupNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.VerificationType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.PatientPayorEligibilitiesCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayorEligibility_User");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.PatientPayorEligibilities)
                .HasForeignKey(d => d.fk_PatientID)
                .HasConstraintName("FK_PatientPayorEligibility_Patient");

            entity.HasOne(d => d.PatientPayor)
                .WithMany(p => p.PatientPayorEligibilities)
                .HasForeignKey(d => d.Fk_PatientPayorID)
                .HasConstraintName("FK_PatientPayorEligibility_PatientPayor");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.PatientPayorEligibilitiesModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPayorEligibility_User1");
        }
    }
}
