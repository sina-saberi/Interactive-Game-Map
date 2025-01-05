using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieProperties
{
    [JsonProperty("id")]
    public long Id { get; set; }
}