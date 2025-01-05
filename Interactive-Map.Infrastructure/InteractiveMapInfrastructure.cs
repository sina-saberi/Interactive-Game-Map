using Interactive_Map.Application.Interfaces;
using Interactive_Map.Infrastructure.Context;
using Interactive_Map.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure
{
    public static class InteractiveMapInfrastructure
    {
        public static void AddInteractiveMapInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InteractiveMapInfrastructure));
            services.AddDbContext<GameMapsDbContext>();


            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IMapRepository, MapRepository>();
        }
    }
}
