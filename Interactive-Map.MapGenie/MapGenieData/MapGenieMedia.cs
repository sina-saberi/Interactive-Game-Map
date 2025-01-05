using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieMedia
{
    [JsonProperty("file_name")] public string FileName { get; set; }
    [JsonProperty("mime_type")] public string MimeType { get; set; }
    [JsonProperty("title")] public string Title { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("url")] public string Url { get; set; }
}