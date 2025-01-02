using Interactive_Map.Services;
using Interactive_Map.Stores;
using Interactive_Map.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows = System.Windows;

namespace Interactive_Map;

public partial class App : Windows.Application
{
    private readonly IServiceProvider _serviceProvider;
    public App()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<NavigationStore>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<GameListViewModel>();
        services.AddSingleton<MapListViewModel>();

        services.AddSingleton<NavigationService<GameListViewModel>>();
        services.AddSingleton<NavigationService<MapListViewModel>>();

    }

    private void SetDefaultViewModel<TViewModel>() where TViewModel : ViewModelBase
    {
        var navigationStore = _serviceProvider.GetRequiredService<NavigationStore>();
        var gameListViewModel = _serviceProvider.GetRequiredService<TViewModel>();
        navigationStore.CurrentViewModel = gameListViewModel;
    }

    protected override void OnStartup(Windows.StartupEventArgs e)
    {
        SetDefaultViewModel<GameListViewModel>();
        MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        MainWindow.Show();
        base.OnStartup(e);
    }
}