using Newtonsoft.Json;

namespace Interactive_Map.WebScraper.MapGenieData;

public class MapGenieCategory
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("group_id")] public int GroupId { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("icon")] public string Icon { get; set; }

    [JsonProperty("info")] public object Info { get; set; }

    [JsonProperty("template")] public object Template { get; set; }

    [JsonProperty("order")] public int Order { get; set; }

    [JsonProperty("has_heatmap")] public bool HasHeatmap { get; set; }

    [JsonProperty("features_enabled")] public bool FeaturesEnabled { get; set; }

    [JsonProperty("display_type")] public string DisplayType { get; set; }

    [JsonProperty("ign_enabled")] public bool IgnEnabled { get; set; }

    [JsonProperty("ign_visible")] public bool IgnVisible { get; set; }

    [JsonProperty("visible")] public bool Visible { get; set; }

    [JsonProperty("description")] public object Description { get; set; }

    [JsonProperty("premium")] public bool Premium { get; set; }
}