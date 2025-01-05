using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieLocation
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("map_id")] public int MapId { get; set; }

    [JsonProperty("region_id")] public object RegionId { get; set; }

    [JsonProperty("category_id")] public int CategoryId { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }
    public Guid NewId { get; set; } = Guid.NewGuid();

    [JsonProperty("latitude")] public double Latitude { get; set; }

    [JsonProperty("longitude")] public double Longitude { get; set; }

    [JsonProperty("features")] public object Features { get; set; }

    [JsonProperty("ign_page_id")] public object IgnPageId { get; set; }

    [JsonProperty("tags")] public List<object> Tags { get; set; }

    [JsonProperty("media")] public List<MapGenieMedia> Media { get; set; }

}