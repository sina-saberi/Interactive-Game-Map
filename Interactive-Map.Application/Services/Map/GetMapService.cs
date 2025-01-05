using AutoMapper;
using Interactive_Map.Application.Extensions;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Interactive_Map.MapGenie;
using Microsoft.EntityFrameworkCore;

namespace Interactive_Map.Application.Services.Map
{
    public class GetMapService(IMapRepository mapRepository, IMapper mapper)
    {
        private readonly IMapRepository _mapRepository = mapRepository;
        private readonly IMapper _mapper = mapper;



        private async Task SyncMapDatas(string gameSlug, string mapSlug)
        {
            var map = await _mapRepository.AsQueryable()
                .Include(x => x.MapConfig)
                .Include(x => x.Groups)
                .Include(x => x.Game)
                //.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Slug == mapSlug && x.Game!.Slug == gameSlug);

            if (map is null) return;

            var mapData = await MapGenieGame
              .Get(x => x.Slug == gameSlug)
              .GetMap(x => x.Slug == mapSlug)
              .GetMapData();
            if (mapData is null) return;

            bool isChanged = false;


            if (map.MapConfig is null && mapData.MapConfig is not null)
            {
                map.MapConfig = _mapper.Map<MapConfig>(mapData.MapConfig);
                isChanged = true;
            }

            if (map.Groups is null || !map.Groups.Any())
            {
                map.Groups = mapData.GetGroups();
                isChanged = true;
            }



            if (isChanged) await _mapRepository.Update(map);
        }

        public async Task<MapDto> ExecuteAsync(string gameSlug, string mapSlug)
        {
            await SyncMapDatas(gameSlug, mapSlug);
            //var result = await repository.Get(gameSlug, mapSlug);
            //return mapper.Map<MapDto>(result);
            throw new NotImplementedException();
        }
    }
}
