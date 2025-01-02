using AutoMapper;
using Interactive_Map.Application.Interfaces;
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
        public async Task<IList<GameListItemDto>> ExecuteAsync()
        {
            var response = await _repository.GetAll();
            return _mapper.Map<IList<GameListItemDto>>(response);
        }
    }
}
