using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.MapGenie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Game
{
    public class GetGameListService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;

        public GetGameListService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private async Task SyncGames()
        {
            var mapGenieGames = await MapGenieGame.GetAll();
            var games = _mapper.Map<IEnumerable<Domain.Entities.Game>>(mapGenieGames);
            await _repository.Merge(games, (a, b) => a.Slug == b.Slug, (source, target) =>
                source.Update(target.Name, target.Slug, true, DateTime.Now));
        }

        public async Task<IList<GameListItemDto>> ExecuteAsync()
        {
            await SyncGames();
            var response = await _repository.GetAll();
            return _mapper.Map<IList<GameListItemDto>>(response);
        }
    }
}
