﻿using Interactive_Map.Domain.Entities;
using Interactive_Map.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Configs
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(3000);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Type).IsRequired().HasDefaultValue(LocationType.Server);


            builder.HasMany(x => x.Medias).WithOne(x => x.Location).HasForeignKey(x => x.LocationId);
            builder.Navigation(x => x.Medias).UsePropertyAccessMode(PropertyAccessMode.Field).HasField("_medias");

            builder.HasOne(x => x.UserLocation).WithOne(x => x.Location).HasForeignKey<UserLocation>(x => x.LocationId);
        }
    }
}
