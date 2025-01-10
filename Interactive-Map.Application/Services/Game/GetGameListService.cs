using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Application.Services.MapGenie;
using Microsoft.EntityFrameworkCore;

namespace Interactive_Map.Application.Services.Game
{
    public class GetGameListService
    {
        private readonly IGameMapsDbContext _context;
        private readonly IMapper _mapper;
        private readonly MapGenieSynchronizeService _synchronizeService;

        public GetGameListService(IGameMapsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _synchronizeService = new MapGenieSynchronizeService(mapper, context);
        }

        public async Task<IEnumerable<GameListItemDto>> ExecuteAsync()
        {
            var games = await _context.Games.ToListAsync();
            await _synchronizeService.SyncGames(games);
            return _mapper.Map<IEnumerable<GameListItemDto>>(games);
        }
    }
}
