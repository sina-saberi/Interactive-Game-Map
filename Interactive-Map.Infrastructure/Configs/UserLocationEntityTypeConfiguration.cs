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
    public class UserLocationEntityTypeConfiguration : IEntityTypeConfiguration<UserLocation>
    {
        public void Configure(EntityTypeBuilder<UserLocation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Notes).IsRequired(false).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Marked).HasDefaultValue(false);
            builder.Property(x => x.Checked).HasDefaultValue(false);
        }
    }
}
