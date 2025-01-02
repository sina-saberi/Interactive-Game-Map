using Interactive_Map.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Configs
{
    public class MapEntityTypeConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(500);

            builder.HasMany(x => x.Groups).WithOne(x => x.Map).HasForeignKey(x => x.MapId);
            builder.HasOne(x => x.MapConfig).WithOne(x => x.Map).HasForeignKey<MapConfig>(x => x.MapId);
        }
    }
}
