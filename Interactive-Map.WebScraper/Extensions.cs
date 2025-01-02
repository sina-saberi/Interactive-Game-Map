using HtmlAgilityPack;
using Interactive_Map.WebScraper.MapGenieData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interactive_Map.WebScraper
{
    public static partial class Extensions
    {
        [GeneratedRegex(@"window\.mapData\s*=\s*(\{.*?\});", RegexOptions.Singleline)]
        public static partial Regex MapDataScriptRegex();

        [GeneratedRegex(@"MARKER_SPRITE_POSITIONS_V3\s*=\s*(\{.*?\});", RegexOptions.Singleline)]
        public static partial Regex MapDataMarkerScriptRegex();
        [GeneratedRegex(@"MARKER_IMAGES_URL\s*=\s*(\'.*?\');", RegexOptions.Singleline)]
        public static partial Regex MapDataMarkerURLScriptRegex();



        public static async Task<IReadOnlyCollection<MapGenieMap>> GetMaps(this Task<MapGenieGame> task)
        {
            var game = await task;
            return await game.GetMaps();
        }

        public static async Task<MapGenieMap> GetMap(this Task<MapGenieGame> task, Func<MapGenieMap, bool> select)
        {
            var game = await task;
            return await game.GetMap(select);
        }

        public static MapGenieMapData? ScrapScript(this HtmlDocument? doc)
        {
            if (doc == null) return null;
            var scriptNodes = doc.DocumentNode.SelectNodes("//script");
            if (scriptNodes == null) return null;
            MapGenieMapData? root = null;
            foreach (var script in scriptNodes)
            {
                if (!script.InnerText.Contains("window.mapData")) continue;
                var match = MapDataScriptRegex().Match(script.InnerText);
                if (!match.Success) continue;
                var json = match.Groups[1].Value;
                root = JsonConvert.DeserializeObject<MapGenieMapData>(json);
            }
            if (root == null) return null;

            ScrapMarkers(doc, root);
            ScrapMarkersURl(doc, root);
            return root;
        }

        public static async Task<MapGenieMapData> GetMapData(this Task<MapGenieMap> task)
        {
            var result = await task;
            return await result.GetMapData();
        }
        private static void ScrapMarkers(HtmlDocument doc, MapGenieMapData dto)
        {
            var scriptNodes = doc.DocumentNode.SelectNodes("//script");
            if (scriptNodes == null) return;
            foreach (var script in scriptNodes)
            {
                if (!script.InnerText.Contains("MARKER_SPRITE_POSITIONS_V3")) continue;
                var match = MapDataMarkerScriptRegex().Match(script.InnerText);
                if (!match.Success) continue;
                var json = match.Groups[1].Value;
                dto.Markers = JsonConvert.DeserializeObject<Dictionary<int, MapGenieMarker>>(json);
            }
        }
        private static void ScrapMarkersURl(HtmlDocument doc, MapGenieMapData dto)
        {
            var scriptNodes = doc.DocumentNode.SelectNodes("//script");
            if (scriptNodes == null) return;
            foreach (var script in scriptNodes)
            {
                if (!script.InnerText.Contains("MARKER_IMAGES_URL")) continue;
                var match = MapDataMarkerURLScriptRegex().Match(script.InnerText);
                if (!match.Success) continue;
                var str = match.Groups[1].Value;
                dto.MarkerUrl = str;
            }
        }
    }
}
