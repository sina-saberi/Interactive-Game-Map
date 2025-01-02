using Newtonsoft.Json;

namespace Interactive_Map.WebScraper.MapGenieData;

public class MapGenieGeometry
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("coordinates")] public double[][][] Coordinates { get; set; }
}