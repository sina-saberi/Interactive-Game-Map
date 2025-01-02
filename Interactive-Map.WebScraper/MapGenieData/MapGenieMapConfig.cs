using Newtonsoft.Json;

namespace Interactive_Map.WebScraper.MapGenieData;

public class MapGenieMapConfig
{
    [JsonProperty("initial_zoom")]
    public int InitialZoom { get; set; }

    [JsonProperty("start_lat")]
    public double StartLat { get; set; }

    [JsonProperty("start_lng")]
    public double StartLng { get; set; }

    [JsonProperty("overlay")]
    public object Overlay { get; set; }

    [JsonProperty("overzoom")]
    public bool Overzoom { get; set; }

    [JsonProperty("tile_sets")]
    public List<MapGenieTileSet> TileSets { get; set; }
}