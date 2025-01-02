using BruTile.Predefined;
using BruTile.Web;
using HarfBuzzSharp;
using Interactive_Map.Application.Services.Map;
using Interactive_Map_Navigation.Helpers;
using Interactive_Map_WindowsApplication.Controls;
using Interactive_Map_WindowsApplication.Services;
using Interactive_Map_WindowsApplication.ViewModels.Layouts;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Limiting;
using Mapsui.Logging;
using Mapsui.Nts;
using Mapsui.Nts.Extensions;
using Mapsui.Projections;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.Tiling.Extensions;
using Mapsui.Tiling.Layers;
using Mapsui.UI.Wpf;
using NetTopologySuite.Geometries;
using System.Windows;
using System.Windows.Input;

namespace Interactive_Map_WindowsApplication.ViewModels.Pages
{
    public class MapViewModel : PageBase
    {
        private readonly string _gameSlug;
        private readonly string _mapSlug;

        [Inject] public MapService? MapService { get; set; }
        [Inject] public TileService? TileService { get; set; }
        public GameMapsMapControl? MapControl { get; set; }
        public ICommand? Command { get; set; }


        public async Task GetData()
        {
            if (MapService is null) return;
            var map = await MapService.GetMap(_gameSlug, _mapSlug);
            MapControl = new GameMapsMapControl(map, TileService);
            OnPropertyChanged(nameof(MapControl));
        }

        public override void OnReady() =>
            Application.Current.Dispatcher.InvokeAsync(GetData);

        public MapViewModel(string gameSlug, string mapSlug)
        {
            _gameSlug = gameSlug;
            _mapSlug = mapSlug;
            Layout = new MainLayoutViewModel();
        }
    }
}
