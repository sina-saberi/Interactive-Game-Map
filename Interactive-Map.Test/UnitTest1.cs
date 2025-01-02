using Interactive_Map.Application;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Infrastructure;
using Interactive_Map.Infrastructure.Repositories;
using Interactive_Map.WebScraper;
using Interactive_Map_WindowsApplication;
using Microsoft.Extensions.DependencyInjection;

namespace Interactive_Map.Test;

public class Tests
{
    private IServiceProvider _serviceProvider;

    [SetUp]
    public void Setup()
    {
        _serviceProvider = ConfigureServices(new ServiceCollection());
    }

    private IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(App));
        services.AddInteractiveMapInfrastructure();
        services.AddInteractiveMapApplication();

        services.AddSingleton<GameService>();
        services.AddSingleton<MapService>();

        return services.BuildServiceProvider();
    }
}