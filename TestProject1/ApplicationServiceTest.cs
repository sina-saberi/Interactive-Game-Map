using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ApplicationServiceTest
    {
        private readonly GetGameListService _getGameListService;
        private readonly GetMapListService _getMapListService;
        private readonly GetMapService _getMapService;
        private readonly IServiceScope _serviceScope;


        public ApplicationServiceTest()
        {
            var startup = new Startup();
            _serviceScope = startup.Services.CreateScope();
            _getGameListService = _serviceScope.ServiceProvider.GetRequiredService<GetGameListService>();
            _getMapListService = _serviceScope.ServiceProvider.GetRequiredService<GetMapListService>();
            _getMapService = _serviceScope.ServiceProvider.GetRequiredService<GetMapService>();
        }


        [Fact]
        public async Task GetAllGames()
        {
            var reulst = await _getGameListService.ExecuteAsync();
            Assert.NotNull(reulst);
            Assert.NotEmpty(reulst);
        }

        [Fact]
        public async Task GetAllMapsByGameSlug()
        {
            var reulst = await _getMapListService.ExecuteAsync("fallout-4");
            Assert.NotNull(reulst);
            Assert.NotEmpty(reulst);
        }

        [Fact]
        public async Task GetMapData()
        {
            using var scope = _serviceScope.ServiceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GameMapsDbContext>();
            dbContext.ChangeTracker.Clear();
            var result = await _getMapService.ExecuteAsync("fallout-4", "commonwealth");
            Assert.NotNull(result);
        }
    }
}
