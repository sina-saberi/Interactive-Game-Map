using AutoMapper;
using Interactive_Map.Application.Mapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Infrastructure.Context;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestProject1.Common
{
    public class XUnitTestFactory
    {
        private readonly GetGameListService _getGameListService;
        private readonly GetMapListService _getMapListService;
        private readonly GetMapService _getMapService;
        private readonly XLoger _xLoger;
        public XUnitTestFactory(ITestOutputHelper output)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InteractiveMapApplicationMapperProfile>();
            });



            var mapper = mapperConfig.CreateMapper();
            _xLoger = new XLoger(output);
            var config = new XUnitDbContextOption(_xLoger);
            var ctx = new GameMapsDbContext(config.GetOptions());

            _getGameListService = new GetGameListService(ctx, mapper);
            _getMapListService = new GetMapListService(ctx, mapper);
            _getMapService = new GetMapService(ctx, mapper);
        }

        public GetGameListService GetGameListService => _getGameListService;
        public GetMapListService GetMapListService => _getMapListService;
        public GetMapService GetMapService => _getMapService;
        public XLoger XLoger => _xLoger;
    }
}
