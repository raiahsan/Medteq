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
    class ActivityMessageConfiguration : IEntityTypeConfiguration<ActivityMessage>
    {
        public void Configure(EntityTypeBuilder<ActivityMessage> entity)
        {
            entity.ToTable("ActivityMessage");


            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.Reipient)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Sender)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity)
                .WithMany(p => p.ActivityMessages)
                .HasForeignKey(d => d.fk_ActivityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_Activity");

            entity.HasOne(d => d.Direction)
                .WithMany(p => p.ActivityMessages)
                .HasForeignKey(d => d.fk_DirectionID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_ActivityDirection");
        }
    }
}
