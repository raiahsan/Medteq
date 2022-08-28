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
    class ActivityDirectionConfiguration : IEntityTypeConfiguration<ActivityDirection>
    {
        public void Configure(EntityTypeBuilder<ActivityDirection> entity)
        {
            entity.ToTable("ActivityDirection");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
