using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieFeature
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("geometry")] public MapGenieGeometry Geometry { get; set; }

    [JsonProperty("properties")] public MapGenieProperties Properties { get; set; }

    [JsonProperty("id")] public long Id { get; set; }
}