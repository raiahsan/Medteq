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
    class ApiLogConfiguration : IEntityTypeConfiguration<ApiLog>
    {
        public void Configure(EntityTypeBuilder<ApiLog> entity)
        {
            entity.ToTable("ApiLog");

            entity.Property(e => e.RequestURL)
                .HasMaxLength(250)
                .IsUnicode(false); 
            
            entity.Property(e => e.RequestByURL)
                .HasMaxLength(100)
                .IsUnicode(false); 
            
            entity.Property(e => e.IPAddress)
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}
