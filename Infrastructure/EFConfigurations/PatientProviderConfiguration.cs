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
    class PatientProviderConfiguration : IEntityTypeConfiguration<PatientProvider>
    {
        public void Configure(EntityTypeBuilder<PatientProvider> entity)
        {
            entity.ToTable("PatientProvider");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.PatientProviders)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientProvider_Patient");

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.PatientProviders)
                .HasForeignKey(d => d.fk_ProviderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientProvider_Provider");

            entity.HasOne(d => d.ProviderType)
                .WithMany(p => p.PatientProviders)
                .HasForeignKey(d => d.fk_ProviderTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientProvider_ProviderType");
        }
    }
}
