using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Context
{

    public class GameMapsDbContext : DbContext, IGameMapsDbContext
    {
        public GameMapsDbContext(DbContextOptions<GameMapsDbContext> options) : base(options)
        { }

        public GameMapsDbContext() { }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Map> Maps => Set<Map>();
        public DbSet<MapConfig> MapConfigs => Set<MapConfig>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Media> Media => Set<Media>();
        public DbSet<UserLocation> UserLocations => Set<UserLocation>();
        public DbSet<UserConfig> Config => Set<UserConfig>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameMapsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "interactive-map");

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            var dbPath = Path.Combine(appDataPath, "data");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
