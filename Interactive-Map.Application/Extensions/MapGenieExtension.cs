using AutoMapper;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Domain.Enums;
using Interactive_Map.MapGenie.MapGenieData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Interactive_Map.Application.Extensions
{
    public static class MapGenieExtension
    {

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

                string newUrl = $"{path}/locationId={location.NewId}".TrimStart('/');
                return $"({newUrl})";
            });
        }

        public static string? GetQueryParameterValue(string url, string parameterName)
        {
            var match = Regex.Match(url, $@"[?&]{parameterName}=([^&]+)");
            return match.Success ? match.Groups[1].Value : null;
        }

        public static IEnumerable<Domain.Entities.Group> GetGroups(this MapGenieMapData mapData)
        {
            var groups = new List<Domain.Entities.Group>();
            mapData.Groups.ForEach(g =>
            {
                if (g.Categories is null) return;

                var categories = new List<Category>();

                g.Categories.ForEach((c) =>
                {
                    var mapGenieLocations = mapData.Locations.Where(x => x.CategoryId == c.Id).ToList();
                    var locations = new List<Location>();

                    mapGenieLocations.ForEach((l) =>
                    {
                        var medias = new List<Media>();

                        l.Media.ForEach(m =>
                        {
                            var media = new Media(m.FileName, m.MimeType, m.Title, m.Type);
                            medias.Add(media);
                        });

                        var newDescription = ReplaceLocationUrlWithGuids(l.Description, mapData.Locations);
                        var location = new Location(l.NewId, l.Title, newDescription, l.Latitude, l.Longitude, LocationType.Server, medias);
                        locations.Add(location);
                    });

                    var category = new Category(c.Title, c.Icon, c.DisplayType, c.Description, locations);
                    categories.Add(category);
                });

                var group = new Domain.Entities.Group(g.Title, g.Order, g.Color, g.Expandable, categories);
                groups.Add(group);
            });
            return groups;
        }
    }
}
