using Interactive_Map.Application.Interfaces;
using Interactive_Map.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Interactive_Map.Infrastructure
{
    public static class InteractiveMapInfrastructure
    {
        public static void AddInteractiveMapInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InteractiveMapInfrastructure));

            services.AddDbContext<GameMapsDbContext>();

            services.AddScoped<IGameMapsDbContext>(provider => provider.GetRequiredService<GameMapsDbContext>());
        }
    }
}
