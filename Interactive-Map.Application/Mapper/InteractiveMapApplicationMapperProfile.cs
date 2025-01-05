using AutoMapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Domain.Entities;
using Interactive_Map.MapGenie;
using Interactive_Map.MapGenie.MapGenieData;

namespace Interactive_Map.Application.Mapper
{
    internal class InteractiveMapApplicationMapperProfile : Profile
    {
        public InteractiveMapApplicationMapperProfile()
        {
            CreateMap<MapGenieMinAndMax, MinAndMax>();
            CreateMap<MapGenieBound, Bound>();
            CreateMap<MapGenieTileSet, TileSet>();
            CreateMap<MapGenieMapConfig, MapConfig>();

            CreateMap<MapGenieMap, Map>()
            .ForMember(x => x.Id, _ => Guid.NewGuid())
            .ForMember(x => x.Name, x => x.MapFrom(c => c.Title))
            .ForMember(x => x.MapConfig, x => x.Ignore())
            .ForMember(x => x.Groups, x => x.Ignore());

            CreateMap<MapGenieGame, Game>()
             .ForMember(x => x.Id, _ => Guid.NewGuid())
             .ForMember(x => x.Name, x => x.MapFrom(c => c.Title));



            CreateMap<Game, GameListItemDto>()
                .ReverseMap();
            CreateMap<Map, MapListItemDto>()
             .ReverseMap();
            CreateMap<Map, MapDto>()
              .ReverseMap();
        }
    }
}
