using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieBound
{
    [JsonProperty("x")]
    public MapGenieMinAndMax X { get; set; }

    [JsonProperty("y")]
    public MapGenieMinAndMax Y { get; set; }
}