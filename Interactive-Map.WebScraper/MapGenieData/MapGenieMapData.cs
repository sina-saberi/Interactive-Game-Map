using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.WebScraper.MapGenieData
{
    public class MapGenieMapData
    {
        [JsonProperty("maps")] public List<MapGenieMapDto> Maps { get; set; }

        [JsonProperty("map")] public MapGenieMapDto MapGenieMap { get; set; }

        [JsonProperty("groups")] public List<MapGenieGroup> Groups { get; set; }

        [JsonProperty("categories")] public Dictionary<int, MapGenieCategory> Categories { get; set; }

        [JsonProperty("regions")] public List<object> Regions { get; set; }
        [JsonProperty("locations")] public List<MapGenieLocation> Locations { get; set; }

        [JsonProperty("heatmapGroups")] public List<object> HeatmapGroups { get; set; }

        [JsonProperty("heatmapCategories")] public List<object> HeatmapCategories { get; set; }

        [JsonProperty("routes")] public List<object> Routes { get; set; }

        [JsonProperty("notes")] public List<object> Notes { get; set; }

        [JsonProperty("maxMarkedLocations")] public int MaxMarkedLocations { get; set; }
        [JsonProperty("mapConfig")] public MapGenieMapConfig MapConfig { get; set; }
        public Dictionary<int, MapGenieMarker>? Markers { get; set; }
        public string? MarkerUrl { get; set; }
    }
}
