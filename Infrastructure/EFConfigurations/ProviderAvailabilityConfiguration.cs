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
    class ProviderAvailabilityConfiguration : IEntityTypeConfiguration<ProviderAvailability>
    {
        public void Configure(EntityTypeBuilder<ProviderAvailability> entity)
        {
            entity.ToTable("ProviderAvailability");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.ProviderAvailbilitiesCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProviderAvailbility_User");

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.ProviderAvailbilities)
                .HasForeignKey(d => d.fk_ProviderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProviderAvailbility_Provider");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.ProviderAvailbilitiesModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProviderAvailbility_User1");
        }
    }
}
