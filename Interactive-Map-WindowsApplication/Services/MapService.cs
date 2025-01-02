using AutoMapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map_WindowsApplication.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Services
{
    public class MapService(IMapper mapper, GetMapListService service, GetMapService getMapService)
    {

        public async Task<IList<MapListItemDtoViewModel>> GetAllMaps(string slug)
        {
            var maps = await service.ExecuteAsync(slug);
            return mapper.Map<List<MapListItemDtoViewModel>>(maps);
        }

        public async Task<MapDto> GetMap(string gameSlug, string MapSlug)
        {
            var result = await getMapService.ExecuteAsync(gameSlug, MapSlug);

            return result;
        }
    }
}
