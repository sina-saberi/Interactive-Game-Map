using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieGroup
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("game_id")]
    public int GameId { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [JsonProperty("expandable")]
    public bool Expandable { get; set; }

    [JsonProperty("categories")]
    public List<MapGenieCategory> Categories { get; set; }
}