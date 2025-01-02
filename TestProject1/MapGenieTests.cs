using Interactive_Map.WebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class MapGenieTests
    {
        [Fact]
        public async Task GetGames()
        {
            var games = await MapGenieGame.GetAll();
            Assert.NotNull(games);
        }

        [Fact]
        public async Task GetGame()
        {
            var games = await MapGenieGame.Get(x => x.Slug == "witcher-3");
            Assert.NotNull(games);
        }

        [Fact]
        public async Task GetGameExternal()
        {
            var games = await MapGenieGame.Get(x => x.Slug == "fallout-4");
            Assert.NotNull(games);
        }



        [Fact]
        public async Task GetMaps()
        {
            var maps = await MapGenieGame.Get(x => x.Slug == "witcher-3")
                .GetMaps();

            Assert.NotNull(maps);
        }
        [Fact]
        public async Task GetMapsExternal()
        {
            var maps = await MapGenieGame.Get(x => x.Slug == "fallout-4")
                .GetMaps();

            Assert.NotNull(maps);
        }

        [Fact]
        public async Task GetMap()
        {
            var map = await MapGenieGame.Get(x => x.Slug == "witcher-3")
              .GetMap(x => x.Slug == "white-orchard");

            Assert.NotNull(map);
        }

        [Fact]
        public async Task GetMapExternal()
        {
            var map = await MapGenieGame.Get(x => x.Slug == "fallout-4")
                .GetMap(x => x.Slug == "far-harbor");

            Assert.NotNull(map);
        }

        [Fact]
        public async Task GetMapData()
        {
            var map = await MapGenieGame.Get(x => x.Slug == "witcher-3")
                .GetMap(x => x.Slug == "white-orchard")
                .GetMapData();

            Assert.NotNull(map);
        }

        [Fact]
        public async Task GetMapDataExternal()
        {
            var map = await MapGenieGame.Get(x => x.Slug == "fallout-4")
                .GetMap(x => x.Slug == "far-harbor")
                .GetMapData();

            Assert.NotNull(map);
        }
    }
}
