﻿using Newtonsoft.Json;

namespace Interactive_Map.WebScraper.MapGenieData;

public class MapGenieMinAndMax
{
    [JsonProperty("max")]
    public int Max { get; set; }

    [JsonProperty("min")]
    public int Min { get; set; }
}