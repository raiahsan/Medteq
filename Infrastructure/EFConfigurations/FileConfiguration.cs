﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFConfigurations
{
    class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> entity)
        {
            entity.ToTable("File");

            entity.Property(e => e.FileSize)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fileSize");

            entity.Property(e => e.FileType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fileType");

            entity.Property(e => e.FileUrl)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fileURL");

            entity.Property(e => e.UploadedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Entity)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.fk_EntityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_File_Entity");

            entity.HasOne(d => d.UploadedByUser)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_File_User");
        }
    }
}
