using Interactive_Map.Application.Interfaces;
using Interactive_Map.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProject1
{
    public class InfTests
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapRepository _mapRepository;
        public InfTests()
        {
            var startup = new Startup();
            _gameRepository = startup.Services.GetRequiredService<IGameRepository>();
            _mapRepository = startup.Services.GetRequiredService<IMapRepository>();
        }

        [Fact]
        public async Task GetAllGamesTest()
        {
            var result = await _gameRepository.GetAll();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }


        [Fact]
        public async Task GetAllMapsTest()
        {
            var result = await _mapRepository.AsQueryable()
                .Include(x => x.Game)
                .Where(x => x.Game!.Slug == "fallout-4")
                .ToListAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task RemoveAllGamesTest()
        {
            var result = await _gameRepository.GetAll();
            await _gameRepository.RemoveRange(x => true);
        }
    }

}
