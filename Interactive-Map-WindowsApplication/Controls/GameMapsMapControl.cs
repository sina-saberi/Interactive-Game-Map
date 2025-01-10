using BruTile.Predefined;
using BruTile.Web;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Domain.Entities;
using Interactive_Map_WindowsApplication.Controls;
using Interactive_Map_WindowsApplication.Services;
using Interactive_Map_WindowsApplication.ViewModels.Dtos;
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
        private readonly MapConfigDtoViewModel _mapConfig;
        private readonly IEnumerable<LocationDtoViewModel> _locations;
        private readonly Func<string, Task<byte[]?>> _funct;

        public int CurrentTileSet { get; set; }
        public GameMapsMapControl(MapConfigDtoViewModel mapConfig, IEnumerable<LocationDtoViewModel> locations, Func<string, Task<byte[]?>> funct)
        {
            _mapConfig = mapConfig;
            _locations = locations;
            _funct = funct;
            Init();
        }
        private void Init()
        {
            var tilesets = _mapConfig.TileSets?.ToList();
            var tileSet = tilesets?[CurrentTileSet];
            if (tileSet is null) return;
            Map.Layers.Add(GetTileLayer(tileSet));
            Map.Navigator.CenterOnAndZoomTo(GetCenter(_mapConfig), GetDefautlZoom(Map, _mapConfig));
            Map.Layers.Add(AddInteractiveMarker());
            Logger.LogDelegate += Loging;
        }

        private MemoryLayer AddInteractiveMarker()
        {
            var features = new List<IFeature>();

            var wgs84 = GeographicCoordinateSystem.WGS84;
            var sphericalMercator = ProjectedCoordinateSystem.WebMercator;
            var transformation = new CoordinateTransformationFactory().CreateFromCoordinateSystems(wgs84, sphericalMercator);

            foreach (var location in _locations)
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
        private static double GetDefautlZoom(Mapsui.Map map, MapConfigDtoViewModel? config)
        {
            return map.Navigator.Resolutions[config?.InitialZoom ?? 9];
        }
        private static MPoint GetCenter(MapConfigDtoViewModel? config)
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
                _funct
            );

            var tileLayer = new TileLayer(tileSource);
            return tileLayer;
        }
    }
}
