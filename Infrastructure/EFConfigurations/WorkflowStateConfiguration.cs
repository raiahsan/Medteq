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
    class WorkflowStateConfiguration : IEntityTypeConfiguration<WorkflowState>
    {
        public void Configure(EntityTypeBuilder<WorkflowState> entity)
        {
            entity.ToTable("WorkflowState");

            entity.Property(e => e.WorkflowStateName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
