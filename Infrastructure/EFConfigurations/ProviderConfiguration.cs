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
    class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> entity)
        {
            entity.ToTable("Provider");

            entity.Property(e => e.Address1)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CommercialNumber)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.DeaexpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("DEAExpiryDate");

            entity.Property(e => e.Deanumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DEANumber");

            entity.Property(e => e.DegreeDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.DoctorGroup).IsUnicode(false);

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IMSRxerID)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LicenseExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.Location)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.MedicalID)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.Note).HasColumnType("text");

            entity.Property(e => e.NPINumber)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.Specialty)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.StateMedicaidID)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Suffix)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.TaxonomyCode)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Upin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UPIN")
                .IsFixedLength(true);

            entity.HasOne(d => d.ParentProvider)
                .WithMany(p => p.ParentProviders)
                .HasForeignKey(d => d.fk_ParentProviderID)
                .HasConstraintName("FK_Provider_Provider");
        }
    }
}
