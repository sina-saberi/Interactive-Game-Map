using Interactive_Map.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Models
{
    public class Map
    {
        public Task<List<MapListDto>> GetAllMaps(GameListDto game)
        {
            var maps = new List<MapListDto>();
            for (int i = 0; i <= 10; i++) maps.Add(new MapListDto());
            return Task.FromResult(maps);
        }

        public Task<MapDto> GetMap(MapListDto dto)
        {
            return Task.FromResult(new MapDto());
        }
    }
}
