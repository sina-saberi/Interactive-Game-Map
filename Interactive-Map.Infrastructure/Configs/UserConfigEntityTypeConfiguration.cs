﻿using Interactive_Map.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        }
    }
}
