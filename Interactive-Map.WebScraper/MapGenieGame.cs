using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.WebScraper
{
    public class MapGenieGame
    {

        private static readonly HtmlWeb _web = new();
        public static async Task<IReadOnlyCollection<MapGenieGame>> GetAll()
        {
            var doc = await _web.LoadFromWebAsync(MapGenieConfig.TargetSite);
            var cards = doc.DocumentNode.SelectNodes(MapGenieConfig.GameSelector);
            return cards.Select(x => new MapGenieGame(x)).ToList();
        }
        public static async Task<MapGenieGame> Get(Func<MapGenieGame, bool> select)
        {
            var games = await GetAll();
            return games.FirstOrDefault(select)
                   ?? throw new Exception("invalid selector");
        }
        public async Task<IReadOnlyCollection<MapGenieMap>> GetMaps()
        {
            return await MapGenieMap.GetAll(this);
        }
        public async Task<MapGenieMap> GetMap(Func<MapGenieMap, bool> select)
        {
            return await MapGenieMap.Get(this, select);
        }

        private MapGenieGame(HtmlNode node)
        {
            if (node is null) return;
            var title = node.SelectSingleNode(".//h4[@class='card-title']")?.InnerText.Trim();
            var imageUrl = node.SelectSingleNode(".//img[@class='card-img-top']")?.GetAttributeValue("src", "");
            var link = node.SelectSingleNode(".//a")?.GetAttributeValue("href", "");

            Title = title ?? throw new ArgumentException(nameof(Title));
            Link = link ?? throw new ArgumentException(nameof(Link));
            ImageUrl = imageUrl ?? throw new ArgumentException(nameof(ImageUrl));
            Slug = MapGenieConfig.GetGameUrl(link);
        }

        public string Title { get; } = string.Empty;
        public string Link { get; } = string.Empty;
        public string ImageUrl { get; } = string.Empty;
        public string Slug { get; } = string.Empty;
    }
}
