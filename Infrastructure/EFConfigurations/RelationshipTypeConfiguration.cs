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
    class RelationshipTypeConfiguration : IEntityTypeConfiguration<RelationshipType>
    {
        public void Configure(EntityTypeBuilder<RelationshipType> entity)
        {
            entity.ToTable("RelationshipType");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasData(
                new RelationshipType
                {
                    ID = 1,
                    Type = "Father",
                    Active = true
                },
                new RelationshipType
                {
                    ID = 2,
                    Type = "Mother",
                    Active = true
                },
                new RelationshipType
                {
                    ID = 3,
                    Type = "Brother",
                    Active = true
                },
                new RelationshipType
                {
                    ID = 4,
                    Type = "Sister",
                    Active = true
                },
                new RelationshipType
                {
                    ID = 5,
                    Type = "Wife",
                    Active = true
                },
                new RelationshipType
                {
                    ID = 6,
                    Type = "Husband",
                    Active = true
                }
            );
        }
    }
}
