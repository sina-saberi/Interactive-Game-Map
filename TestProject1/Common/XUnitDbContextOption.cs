using Interactive_Map.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestProject1.Common
{
    public class XUnitDbContextOption
    {
        private readonly XLoger _loger;
        public XUnitDbContextOption(XLoger loger)
        {
            _loger = loger;
        }

        public DbContextOptions<GameMapsDbContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameMapsDbContext>();

            var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "interactive-map");

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            var dbPath = Path.Combine(appDataPath, "data");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");


            optionsBuilder.AddInterceptors(new LoggingDbCommandInterceptor(_loger));
            optionsBuilder.EnableSensitiveDataLogging();


            return optionsBuilder.Options;
        }
    }
}
