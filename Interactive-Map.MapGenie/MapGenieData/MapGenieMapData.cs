using Interactive_Map.MapGenie.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interactive_Map.MapGenie.MapGenieData
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

        public IEnumerable<DGGroup> ToGropsDtos()
        {
            var groups = new List<DGGroup>();
            Groups.ForEach(g =>
            {
                if (g.Categories is null) return;

                var categories = new List<DGCategory>();

                g.Categories.ForEach((c) =>
                {
                    var mapGenieLocations = Locations.Where(x => x.CategoryId == c.Id).ToList();
                    var locations = new List<DGLocation>();

                    mapGenieLocations.ForEach((l) =>
                    {
                        var medias = new List<DGMedia>();

                        l.Media.ForEach(m =>
                        {
                            var media = new DGMedia(m.FileName, m.MimeType, m.Title, m.Type);
                            medias.Add(media);
                        });

                        var newDescription = ReplaceLocationUrlWithGuids(l.Description, Locations);
                        var location = new DGLocation(l.Title, newDescription, l.Latitude, l.Longitude, medias);
                        locations.Add(location);
                    });

                    var category = new DGCategory(c.Title, c.Icon, c.DisplayType, c.Description, locations);
                    categories.Add(category);
                });

                var group = new DGGroup(g.Title, g.Order, g.Color, g.Expandable, categories);
                groups.Add(group);
            });
            return groups;
        }

        public static string? ReplaceLocationUrlWithGuids(string? markdown, List<MapGenieLocation> locations)
        {
            if (string.IsNullOrEmpty(markdown) || locations == null) return markdown;

            string pattern = @"\((https?://[^/]+(/[^\?]*)?\?locationIds=\d+)\)";
            return Regex.Replace(markdown, pattern, match =>
            {
                string originalUrl = match.Groups[1].Value;
                string path = match.Groups[2].Value ?? string.Empty;

                var locationId = GetQueryParameterValue(originalUrl, "locationIds");
                if (locationId == null) return match.Value;

                var location = locations.FirstOrDefault(l => l.Id.ToString().Equals(locationId));
                if (location == null) return match.Value;

                string newUrl = $"{path}/locationId={location.Id}".TrimStart('/');
                return $"({newUrl})";
            });
        }

        public static string? GetQueryParameterValue(string url, string parameterName)
        {
            var match = Regex.Match(url, $@"[?&]{parameterName}=([^&]+)");
            return match.Success ? match.Groups[1].Value : null;
        }
    }
}
