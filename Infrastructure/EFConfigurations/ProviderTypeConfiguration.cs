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
    class ProviderTypeConfiguration : IEntityTypeConfiguration<ProviderType>
    {
        public void Configure(EntityTypeBuilder<ProviderType> entity)
        {
            entity.ToTable("ProviderType");

            entity.Property(e => e.Type)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false);

            entity.HasData(new ProviderType
            {
                ID = 1,
                Type = "Primary",
                Active = true
            },
            new ProviderType
            {
                ID = 2,
                Type = "Ordering",
                Active = true
            });
        }
    }
}
