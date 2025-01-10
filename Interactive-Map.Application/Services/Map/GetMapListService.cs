using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.MapGenie;
using Interactive_Map.Domain.Entities;
using Interactive_Map.MapGenie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class GetMapListService
    {
        private readonly IGameMapsDbContext _context;
        private readonly IMapper _mapper;
        private readonly MapGenieSynchronizeService _synchronizeService;

        public GetMapListService(IGameMapsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _synchronizeService = new MapGenieSynchronizeService(mapper, context);
        }

        public async Task<IEnumerable<MapListItemDto>> ExecuteAsync(string slug)
        {
            var game = _context.Games
                .Include(x => x.Maps)
                .FirstOrDefault(x => x.Slug == slug) ?? throw new Exception("invalid slug");

            await _synchronizeService.SyncMaps(game);
            return _mapper.Map<IEnumerable<MapListItemDto>>(game.Maps);
        }
    }
}
