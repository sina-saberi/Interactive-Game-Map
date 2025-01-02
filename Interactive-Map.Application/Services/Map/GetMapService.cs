using AutoMapper;
using Interactive_Map.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class GetMapService(IMapRepository repository, IMapper mapper)
    {
        public async Task<MapDto> ExecuteAsync(string gameSlug, string mapSlug)
        {
            //var result = await repository.Get(gameSlug, mapSlug);
            //return mapper.Map<MapDto>(result);
            throw new NotImplementedException();
        }
    }
}
