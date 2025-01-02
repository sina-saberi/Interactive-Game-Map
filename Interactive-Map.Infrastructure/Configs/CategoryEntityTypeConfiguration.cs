using Interactive_Map.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Configs
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(3000);
            builder.Property(x => x.Icon).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.DisplayType).IsRequired(false).HasMaxLength(500);

            builder.HasMany(x => x.Locations).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
