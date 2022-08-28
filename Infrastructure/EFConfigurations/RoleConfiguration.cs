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
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasData(new Role
                 {
                     ID = 1,
                     RoleName = "Admin",
                     Active = true
                 });
        }
    }
}
