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
    class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> entity)
        {
            entity.ToTable("ExceptionLog");

            entity.Property(e => e.Method)
                .HasMaxLength(50)
                .IsUnicode(false); 
            
            entity.Property(e => e.RequestUrl)
                .HasMaxLength(100)
                .IsUnicode(false); 
        }
    }
}
