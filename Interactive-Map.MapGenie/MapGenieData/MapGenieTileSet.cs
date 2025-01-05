using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieTileSet
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("map_id")]
    public int MapId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; }

    [JsonProperty("extension")]
    public string Extension { get; set; }

    [JsonProperty("pattern")]
    public string Pattern { get; set; }

    [JsonProperty("min_zoom")]
    public int MinZoom { get; set; }

    [JsonProperty("max_zoom")]
    public int MaxZoom { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }

    [JsonProperty("bounds")]
    [JsonConverter(typeof(OptionalDictionaryConverter<int, MapGenieBound>))]
    public Dictionary<int,MapGenieBound> Bounds { get; set; }
}