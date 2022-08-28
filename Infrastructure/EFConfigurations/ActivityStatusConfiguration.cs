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
    class ActivityStatusConfiguration : IEntityTypeConfiguration<ActivityStatus>
    {
        public void Configure(EntityTypeBuilder<ActivityStatus> entity)
        {
            entity.ToTable("ActivityStatus");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
