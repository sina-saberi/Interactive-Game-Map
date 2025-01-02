using BruTile.Predefined;
using BruTile.Web;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Domain.Entities;
using Interactive_Map_WindowsApplication.Controls;
using Interactive_Map_WindowsApplication.Services;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Logging;
using Mapsui.Nts.Extensions;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling.Layers;
using Mapsui.UI.Wpf;
using NetTopologySuite.Geometries;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Interactive_Map_WindowsApplication.Controls
{
    public class GameMapsMapControl : MapControl
    {
        private readonly MapDto _mapDto;
        private readonly TileService? _tileService;

        public int CurrentTileSet { get; set; }
        public GameMapsMapControl(MapDto mapDto, TileService? tileService)
        {
            _mapDto = mapDto;
            _tileService = tileService;
            Init();
        }
        private void Init()
        {
            var tilesets = _mapDto.MapConfig?.TileSets?.ToList();
            var tileSet = tilesets?[CurrentTileSet];
            if (tileSet is null) return;
            Map.Layers.Add(GetTileLayer(tileSet));
            Map.Navigator.CenterOnAndZoomTo(GetCenter(_mapDto.MapConfig), GetDefautlZoom(Map, _mapDto.MapConfig));
            Map.Layers.Add(AddInteractiveMarker(_mapDto));
            Logger.LogDelegate += Loging;
        }
        private static MemoryLayer AddInteractiveMarker(MapDto mapDto)
        {
            var features = new List<IFeature>();

            var wgs84 = GeographicCoordinateSystem.WGS84;
            var sphericalMercator = ProjectedCoordinateSystem.WebMercator;
            var transformation = new CoordinateTransformationFactory().CreateFromCoordinateSystems(wgs84, sphericalMercator);

            if (mapDto.Groups is not null)
            {
                foreach (var group in mapDto.Groups)
                {
                    if (group.Categories is null) continue;

                    foreach (var category in group.Categories)
                    {
                        if (category.Locations is null) continue;

                        foreach (var location in category.Locations)
                        {
                            var mercatorCoords = transformation.MathTransform.Transform(new double[] { location.Longitude, location.Latitude });
                            var markerPoint = new NetTopologySuite.Geometries.Point(new Coordinate(mercatorCoords[0], mercatorCoords[1]));
                            var feature = new Mapsui.Nts.GeometryFeature
                            {
                                Geometry = markerPoint
                            };

                            feature["Name"] = location.Title;
                            feature.Styles.Add(new SymbolStyle
                            {
                                Fill = new Brush(Color.Red),
                                Outline = new Pen { Color = Color.Black, Width = 2 },
                                SymbolScale = 0.5,
                                Opacity = 0.8f
                            });

                            features.Add(feature);
                        }
                    }
                }
            }
            return new MemoryLayer
            {
                Name = "MarkersLayer",
                Features = features
            };
        }
        private static void Loging(LogLevel level, string arg2, Exception? exception)
        {
            Console.WriteLine(arg2);
        }
        private static double GetDefautlZoom(Mapsui.Map map, MapConfig? config)
        {
            return map.Navigator.Resolutions[config?.InitialZoom ?? 9];
        }
        private static MPoint GetCenter(MapConfig? config)
        {
            if (config is null) return new MPoint();
            var center = new MPoint(config.StartLng, config.StartLat);
            var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(center.X, center.Y);
            return sphericalMercatorCoordinate.ToMPoint();
        }
        private TileLayer GetTileLayer(TileSet tileSet)
        {
            var tileSource = new CustomTileSource(
            new GlobalSphericalMercator(),
                tileSet.Pattern,
                name: "CustomTiles",
                _tileService
            );

            var tileLayer = new TileLayer(tileSource);
            return tileLayer;
        }
    }
}

//public static readonly DependencyProperty MapProperty =
//      DependencyProperty.Register(
//         nameof(MapDto),
//         typeof(MapDto),
//         typeof(GameMapsMapControl),
//         new PropertyMetadata(null, OnMapChanged));

//public MapDto MapDto
//{
//    get => (MapDto)GetValue(MapProperty);
//    set => SetValue(MapProperty, value);
//}
//public int CurrentTileSet { get; set; } = 0;

//private static void OnMapChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//{
//    if (d is GameMapsMapControl control && e.NewValue is MapDto newMap)
//    {
//        control.MapDto = newMap;
//        control.Init();
//    }
//}