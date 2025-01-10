using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Application.Services.MapGenie;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Domain.Extensions;
using Interactive_Map.MapGenie;
using Interactive_Map.MapGenie.MapGenieData;
using Microsoft.EntityFrameworkCore;


namespace Interactive_Map.Application.Services.Map
{
    public class GetMapService
    {
        private readonly IMapper _mapper;
        private readonly IGameMapsDbContext _context;
        private readonly MapGenieSynchronizeService _synchronizeService;
        public GetMapService(IGameMapsDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _synchronizeService = new MapGenieSynchronizeService(mapper, context);
        }



        public async Task<MapDataDto> ExecuteAsync(string gameSlug, string mapSlug)
        {
            var map = await _context.Maps
                .Include(x => x.MapConfig)
                .Include(x => x.Groups)
                .ThenInclude(x => x.Categories)
                .ThenInclude(x => x.Locations)
                .ThenInclude(x => x.Medias)
                .Include(x => x.Game)
                .FirstOrDefaultAsync(x => x.Slug == mapSlug && x.Game!.Slug == gameSlug) ?? throw new Exception("invalid slug");

            await _synchronizeService.SyncMapData(map);


            var groups = _mapper.Map<IEnumerable<GroupDto>>(map.Groups);
            var config = _mapper.Map<MapConfigDto>(map.MapConfig);
            var locations = _mapper.Map<IEnumerable<LocationDto>>(map.Groups
                .SelectMany(x => x.Categories)
                .SelectMany(x => x.Locations));


            return new MapDataDto(locations, groups, config);
        }
    }
}
