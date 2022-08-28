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
    class UserToRoleConfiguration : IEntityTypeConfiguration<UserToRole>
    {
        public void Configure(EntityTypeBuilder<UserToRole> entity)
        {
            entity.ToTable("UserToRole");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.UserToRoles)
                .HasForeignKey(d => d.fk_RoleID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToRole_Role");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserToRoles)
                .HasForeignKey(d => d.fk_UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToRole_User");
        }
    }
}
