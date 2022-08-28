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
    class ActivityEmailConfiguration : IEntityTypeConfiguration<ActivityEmail>
    {
        public void Configure(EntityTypeBuilder<ActivityEmail> entity)
        {
            entity.ToTable("ActivityEmail");


            entity.Property(e => e.BCC)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Body).IsUnicode(false);

            entity.Property(e => e.CC)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Recipients)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Sender)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity)
                .WithMany(p => p.ActivityEmails)
                .HasForeignKey(d => d.fk_ActivityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Email_Activity");
        }
    }
}
