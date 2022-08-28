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
    class LeadTypeConfiguration : IEntityTypeConfiguration<LeadType>
    {
        public void Configure(EntityTypeBuilder<LeadType> entity)
        {
            entity.ToTable("LeadType");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasData(
                new LeadType
                {
                    ID = 1,
                    Name = "Primary",
                    Active = true
                },
                new LeadType
                {
                    ID = 2,
                    Name = "Secondary",
                    Active = true
                }
            );
        }
    }
}
