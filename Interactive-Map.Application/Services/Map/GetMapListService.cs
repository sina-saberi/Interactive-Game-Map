using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Application.Services.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class GetMapListService
    {
        private readonly IMapRepository _repository;
        private readonly IMapper _mapper;

        public GetMapListService(IMapRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<MapListItemDto>> ExecuteAsync(string slug)
        {
            //var response = await _repository.GetAll(slug);
            //return _mapper.Map<IReadOnlyList<MapListItemDto>>(response);
            throw new NotImplementedException();
        }
    }
}
