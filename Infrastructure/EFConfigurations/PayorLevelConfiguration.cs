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
    class PayorLevelConfiguration : IEntityTypeConfiguration<PayorLevel>
    {
        public void Configure(EntityTypeBuilder<PayorLevel> entity)
        {
            entity.ToTable("PayorLevel");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasData(
                new PayorLevel
                {
                    ID = 1,
                    Name = "Primary",
                    Active = true
                },
                new PayorLevel
                {
                    ID = 2,
                    Name = "Secondary",
                    Active = true
                },
                new PayorLevel
                {
                    ID = 3,
                    Name = "Tertiary",
                    Active = true
                }
            );
        }
    }
}
