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
    class ActivityNoteConfiguration : IEntityTypeConfiguration<ActivityNote>
    {
        public void Configure(EntityTypeBuilder<ActivityNote> entity)
        {
            entity.ToTable("ActivityNote");


            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);


            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity)
                .WithMany(p => p.ActivityNotes)
                .HasForeignKey(d => d.fk_ActivityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Note_Activity");
        }
    }
}
