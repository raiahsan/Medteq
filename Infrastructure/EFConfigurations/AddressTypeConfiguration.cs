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
    class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> entity)
        {
            entity.ToTable("AddressType");

            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasData(
                new AddressType
                {
                    ID = 1,
                    TypeName = "Billing",
                    Active = true
                },
                new AddressType
                {
                    ID = 2,
                    TypeName = "Shipping",
                    Active = true
                }
           );
        }
    }
}
