using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Application.Services.Tile;
using Microsoft.Extensions.DependencyInjection;

namespace Interactive_Map.Application
{
    public static class InteractiveMapApplication
    {
        public static void AddInteractiveMapApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InteractiveMapApplication));
            services.AddScoped<GetGameListService>();
            services.AddScoped<GetMapListService>();
            services.AddScoped<GetMapService>();
            services.AddScoped<GetTileService>();
        }
    }
}
