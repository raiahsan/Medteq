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
    class ContactMethodConfiguration : IEntityTypeConfiguration<ContactMethod>
    {
        public void Configure(EntityTypeBuilder<ContactMethod> entity)
        {
            entity.ToTable("ContactMethod");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasData(
                new ContactMethod
                {
                    ID = 1,
                    Name = "Primary",
                    Active = true
                },
                new ContactMethod
                {
                    ID = 2,
                    Name = "Secondary",
                    Active = true
                }
            );
        }
    }
}
