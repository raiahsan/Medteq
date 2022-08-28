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
    class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
    {
        public void Configure(EntityTypeBuilder<MaritalStatus> entity)
        {
            entity.ToTable("MaritalStatus");

            entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasData(
                new MaritalStatus
                {
                    ID = 1,
                    Value = "Married",
                    Active = true
                },
                new MaritalStatus
                {
                    ID = 2,
                    Value = "Single",
                    Active = true
                },
                new MaritalStatus
                {
                    ID = 3,
                    Value = "Divorced",
                    Active = true
                },
                new MaritalStatus
                {
                    ID = 4,
                    Value = "Widowed",
                    Active = true
                }
            );
        }
    }
}
