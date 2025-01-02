using Interactive_Map.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Configs
{
    public class MapConfigEntityTypeConfiguration : IEntityTypeConfiguration<MapConfig>
    {
        public void Configure(EntityTypeBuilder<MapConfig> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TileSets)
                   .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<IEnumerable<TileSet>>(v)
                    )
                   .HasColumnType("TEXT");
        }
    }
}
