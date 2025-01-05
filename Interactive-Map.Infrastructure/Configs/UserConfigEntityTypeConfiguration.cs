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
    public class UserConfigEntityTypeConfiguration : IEntityTypeConfiguration<UserConfig>
    {
        public void Configure(EntityTypeBuilder<UserConfig> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SpecialMapLinks)
                 .HasConversion(
                      v => JsonConvert.SerializeObject(v),
                      v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
                  )
                 .HasColumnType("TEXT");

            builder.Property(x => x.SpecialGameLinks)
                .HasConversion(
                     v => JsonConvert.SerializeObject(v),
                     v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
                 )
                .HasColumnType("TEXT");
        }
    }
}
