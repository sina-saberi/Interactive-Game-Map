﻿using Newtonsoft.Json;

namespace Interactive_Map.MapGenie.MapGenieData;

public class MapGenieMapDto(string name, string slug)
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("title")] public string Title { get; set; } = name;

    [JsonProperty("slug")] public string Slug { get; set; } = slug;
  
}