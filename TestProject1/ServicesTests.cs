using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Application.Mapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Sqlite.Update.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1;
using TestProject1.Common;
using Xunit.Abstractions;

namespace TestProject1
{

    public class ServicesTests
    {

        private readonly XUnitTestFactory _factory;
        public ServicesTests(ITestOutputHelper output)
        {
            _factory = new XUnitTestFactory(output);
        }


        [Fact]
        public async Task GetGames()
        {
            var result = await _factory.GetGameListService.ExecuteAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("fallout-4")]
        public async Task GetMaps(string slug)
        {
            var result = await _factory.GetMapListService.ExecuteAsync(slug);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("fallout-4", "commonwealth")]
        public async Task GetMapData(string gameSlug, string mapSlug)
        {
            var result = await _factory.GetMapService.ExecuteAsync(gameSlug, mapSlug);
            Assert.NotNull(result);
        }
    }
}