using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Application.Services.Game;
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
        private readonly IGameRepository _gameRepository;
        private readonly IMapRepository _repository;
        private readonly IMapper _mapper;

        public GetMapListService(IMapRepository repository, IGameRepository gameRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task SyncMaps(string slug)
        {
            var game = await _gameRepository.Get(x => x.Slug == slug);
            if (game is null) return;

            var result = await MapGenieGame.Get(x => x.Slug == slug).GetMaps();
            var maps = result.Select(x => new Domain.Entities.Map(x.Title, x.Slug, game.Id));
            if (maps is null) return;

            await _repository.Merge(maps, (a, b) => a.Slug == b.Slug && a.GameId == b.GameId, (source, target) => source.Update(target.Name, target.Slug));
        }

        public async Task<IEnumerable<MapListItemDto>> ExecuteAsync(string slug)
        {
            await SyncMaps(slug);
            var response = await _repository.AsQueryable()
                .Include(x => x.Game)
                .Where(x => x.Game!.Slug == slug)
                .ToListAsync();


            return _mapper.Map<IReadOnlyList<MapListItemDto>>(response);
        }
    }
}
