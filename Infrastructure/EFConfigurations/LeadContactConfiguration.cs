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
    class LeadContactConfiguration : IEntityTypeConfiguration<LeadContact>
    {
        public void Configure(EntityTypeBuilder<LeadContact> entity)
        {
            entity.ToTable("LeadContact");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.MobileNumber)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.HasOne(d => d.ContactMethod)
                .WithMany(p => p.LeadContacts)
                .HasForeignKey(d => d.fk_ContactMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeadContact_ContactMethod");

            entity.HasOne(d => d.Lead)
                .WithMany(p => p.LeadContacts)
                .HasForeignKey(d => d.fk_LeadID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeadContact_Lead");
        }
    }
}
