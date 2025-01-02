using HtmlAgilityPack;
using Interactive_Map.WebScraper.MapGenieData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interactive_Map.WebScraper
{
    public class MapGenieMap
    {
        private static readonly HtmlWeb _web = new();

        private static IReadOnlyCollection<MapGenieMap>? FromCards(HtmlDocument doc)
        {
            var cards = doc.DocumentNode.SelectNodes(MapGenieConfig.MapSelector);
            if (cards is null || cards.Count == 0) return null;
            return cards.Select(x => new MapGenieMap(x)).ToList();
        }

        private static IReadOnlyCollection<MapGenieMap> FromScript(HtmlDocument doc, string link)
        {
            var mapData = doc.ScrapScript();
            if (mapData is null) throw new Exception(nameof(mapData));
            return mapData.Maps.Select(x => new MapGenieMap(x, link)).ToList();
        }

        public static async Task<IReadOnlyCollection<MapGenieMap>> GetAll(MapGenieGame game)
        {
            var doc = await _web.LoadFromWebAsync(game.Link);
            return FromCards(doc) ?? FromScript(doc, game.Link);
        }

        public static async Task<MapGenieMap> Get(MapGenieGame game, Func<MapGenieMap, bool> select)
        {
            var maps = await GetAll(game);
            return maps.First(select);
        }

        public async Task<MapGenieMapData> GetMapData()
        {
            var doc = await _web.LoadFromWebAsync(Link);
            var data = doc.ScrapScript() ?? throw new ArgumentNullException(nameof(MapGenieMapData));
            return data;
        }

        private MapGenieMap(HtmlNode node)
        {
            var title = node.SelectSingleNode(".//h4[@class='card-title']")?.InnerText.Trim();
            var imageUrl = node.SelectSingleNode(".//img[@class='card-img-top']")?.GetAttributeValue("src", "");
            var link = node.SelectSingleNode(".//a")?.GetAttributeValue("href", "");

            Title = title ?? throw new ArgumentException(nameof(Title));
            Link = link ?? throw new ArgumentException(nameof(Link));
            ImageUrl = imageUrl ?? throw new ArgumentException(nameof(ImageUrl));
            Slug = MapGenieConfig.GetMapUrl(link);
        }

        private MapGenieMap(MapGenieData.MapGenieMapDto maps, string link)
        {
            Title = maps.Title ?? throw new ArgumentException(nameof(Title));
            Link = link + "/" + maps.Slug ?? throw new ArgumentException(nameof(Link));
            Slug = MapGenieConfig.GetMapUrl(Link);
        }

        public string Title { get; } = string.Empty;
        public string Link { get; } = string.Empty;
        public string ImageUrl { get; } = string.Empty;
        public string Slug { get; } = string.Empty;
    }
}
