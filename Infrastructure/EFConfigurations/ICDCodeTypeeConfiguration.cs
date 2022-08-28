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
    class ICDCodeTypeeConfiguration : IEntityTypeConfiguration<ICDCodeType>
    {
        public void Configure(EntityTypeBuilder<ICDCodeType> entity)
        {
            entity.ToTable("ICDCodeType");

            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasData(
                new ICDCodeType
                {
                    ID = 1,
                    TypeName = "ICD-9",
                    Active = true
                },
                new ICDCodeType
                {
                    ID = 2,
                    TypeName = "ICD-10",
                    Active = true
                }
           );
        }
    }
}
