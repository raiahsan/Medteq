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
    class ProviderUnavailabilityConfiguration : IEntityTypeConfiguration<ProviderUnavailability>
    {
        public void Configure(EntityTypeBuilder<ProviderUnavailability> entity)
        {
            entity.ToTable("ProviderUnavailability");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.ProviderUnavailbilities)
                .HasForeignKey(d => d.fk_ProviderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProviderUnavailbility_Provider");
        }
    }
}
