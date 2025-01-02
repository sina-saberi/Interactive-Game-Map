using Interactive_Map.Application;
using Interactive_Map.Infrastructure;
using Interactive_Map_Navigation.Services;
using Interactive_Map_Navigation.Stores;
using Interactive_Map_WindowsApplication.Services;
using Interactive_Map_WindowsApplication.ViewModels.Pages;
using Interactive_Map_WindowsApplication.ViewModels.Windows;
using Interactive_Map_WindowsApplication.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Interactive_Map_WindowsApplication
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            _serviceProvider = ConfigureServices(new ServiceCollection());
        }

        private IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(App));
            services.AddInteractiveMapInfrastructure();
            services.AddInteractiveMapApplication();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<NavigationService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<GameService>();
            services.AddSingleton<MapService>();
            services.AddSingleton<TileService>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationService = _serviceProvider.GetRequiredService<NavigationService>();
            var mainVeiwModel = _serviceProvider.GetRequiredService<MainViewModel>();
            MainWindow = new MainView(mainVeiwModel);

            navigationService.Navigate(() => new MapViewModel("fallout-4", "commonwealth"));
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
