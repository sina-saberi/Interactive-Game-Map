using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.WebScraper
{
    public static class MapGenieConfig
    {
        public const string GameSelector = "//div[contains(@class, 'col-lg-3') and contains(@class, 'col-12') and contains(@class, 'game-card-wrapper')]";
        public const string MapSelector = "//div[contains(@class, 'col-lg-3') and contains(@class, 'col-sm-6')]";
        public const string TargetSite = "https://mapgenie.io";
        public static readonly Dictionary<string, string> _specialLinks = new()
        {
            {"https://fallout4map.com","fallout-4"},
            {"https://gta-5-map.com","gta-5"},
            {"https://rdr2map.com","red-dead-redemption-2"},
        };

        private static string ReplaceBaseSiteUrl(this string url)
        {
            return url.Replace(TargetSite, "")
                .Replace("maps/", "");
        }

        private static string ReplaceSpecialUrls(this string url)
        {
            foreach (var item in _specialLinks)
            {
                url = url.Replace(item.Key, item.Value);
            }

            return url;
        }

        private static string ReplaceWithLastSegment(this string url)
        {
            var segments = url.Split("/");
            return segments.Last();
        }

        public static string GetGameUrl(string url)
        {
            url = url.ReplaceSpecialUrls();
            url = url.ReplaceWithLastSegment();
            return url;
        }
        public static string GetMapUrl(string url)
        {
            url = url.ReplaceBaseSiteUrl();
            url = url.ReplaceSpecialUrls();
            url = url.ReplaceWithLastSegment();
            return url;
        }
    }
}
