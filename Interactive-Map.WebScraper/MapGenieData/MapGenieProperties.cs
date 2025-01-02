using Newtonsoft.Json;

namespace Interactive_Map.WebScraper.MapGenieData;

public class MapGenieProperties
{
    [JsonProperty("id")]
    public long Id { get; set; }
}