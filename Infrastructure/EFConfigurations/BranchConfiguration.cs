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
    class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity)
        {
            entity.ToTable("Branch");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BranchName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BranchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.NPI)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TaxID)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TaxonomyCode)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.BranchesCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branch_User");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.BranchesModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branch_User1");

            entity.HasOne(d => d.State)
                .WithMany(p => p.Branches)
                .HasForeignKey(d => d.fk_StateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branch_State");
        }
    }
}
