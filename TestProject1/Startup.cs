﻿

using Interactive_Map.Application;
using Interactive_Map.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1
{
    public class Startup
    {
        private readonly IServiceProvider _serviceProvider;
        public Startup()
        {
            _serviceProvider = ConfigureServices(new ServiceCollection());
        }

        private IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddInteractiveMapInfrastructure();
            services.AddInteractiveMapApplication();
            return services.BuildServiceProvider();
        }

        public IServiceProvider Services => _serviceProvider;
    }
}
