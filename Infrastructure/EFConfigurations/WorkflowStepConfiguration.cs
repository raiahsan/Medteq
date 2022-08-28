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
    class WorkflowStepConfiguration : IEntityTypeConfiguration<WorkflowStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowStep> entity)
        {
            entity.ToTable("WorkflowStep");

            entity.Property(e => e.LabelAlias)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Workflow)
                .WithMany(p => p.WorkflowSteps)
                .HasForeignKey(d => d.fk_WorkflowID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowStep_Workflow");

            entity.HasOne(d => d.RegressToStep)
                .WithMany(p => p.InverseRegressToStep)
                .HasForeignKey(d => d.RegressToStepID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowStep_WorkflowStep");
        }
    }
}
