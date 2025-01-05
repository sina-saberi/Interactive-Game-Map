using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieRegions
{
    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("map_id")] public long MapId { get; set; }

    [JsonProperty("parent_region_id")] public object ParentRegionId { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("subtitle")] public object Subtitle { get; set; }

    [JsonProperty("features")] public MapGenieFeature[] Features { get; set; }

    [JsonProperty("center_x")] public object CenterX { get; set; }

    [JsonProperty("center_y")] public object CenterY { get; set; }

    [JsonProperty("order")] public long Order { get; set; }
}