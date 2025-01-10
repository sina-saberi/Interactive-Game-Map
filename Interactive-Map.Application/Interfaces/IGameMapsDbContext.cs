using Interactive_Map.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Interfaces
{
    public interface IGameMapsDbContext
    {
        public DbSet<Game> Games { get; }
        public DbSet<Map> Maps { get; }
        public DbSet<MapConfig> MapConfigs { get; }
        public DbSet<Group> Groups { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Location> Locations { get; }
        public DbSet<Media> Media { get; }
        public DbSet<UserLocation> UserLocations { get; }
        public DbSet<UserConfig> Config { get; }

        public int SaveChanges();
        public int SaveChanges(bool acceptAllChangesOnSuccess);
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
