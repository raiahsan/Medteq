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
    class LeadSourceConfiguration : IEntityTypeConfiguration<LeadSource>
    {
        public void Configure(EntityTypeBuilder<LeadSource> entity)
        {
            entity.ToTable("LeadSource");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasData(
                new LeadSource
                {
                    ID = 1,
                    Name = "Salesforce",
                    Active = true
                },
                new LeadSource
                {
                    ID = 2,
                    Name = "Call",
                    Active = true
                }
            );
        }
    }
}
