using AutoMapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Application.Services.MapGenie;
using Interactive_Map.Domain.Entities;
using Interactive_Map.MapGenie;
using Interactive_Map.MapGenie.Dto;
using Interactive_Map.MapGenie.MapGenieData;

namespace Interactive_Map.Application.Mapper
{
    public class InteractiveMapApplicationMapperProfile : Profile
    {
        public InteractiveMapApplicationMapperProfile()
        {
            CreateMap<MapGenieMedia, Media>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.LocationId, x => x.Ignore())
                .ForMember(x => x.Location, c => c.Ignore());

            CreateMap<MapGenieLocation, Location>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.CategoryId, x => x.Ignore())
                .ForMember(x => x.Category, x => x.Ignore())
                .ForMember(x => x.Medias, x => x.Ignore())
                .ForMember(x => x.RefrenceId, x => x.MapFrom(c => c.Id))
                .AfterMap(MapGenieLocationAfterMap);

            CreateMap<MapGenieCategory, Category>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.GroupId, x => x.Ignore())
                .ForMember(x => x.Locations, x => x.Ignore())
                .ForMember(x => x.RefrenceId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.Locations, x => x.Ignore())
                .AfterMap(MapGenieCategoryAfterMap);

            CreateMap<MapGenieGroup, Group>()
                .ForMember(x => x.RefrenceId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.Categories, x => x.Ignore())
                .ForMember(dest => dest.MapId, x => x.Ignore())
                .AfterMap(MapGenieGropsAfterMap);

            CreateMap<MapGenieMinAndMax, MinAndMax>();
            CreateMap<MapGenieBound, Bound>();
            CreateMap<MapGenieTileSet, TileSet>();
            CreateMap<MapGenieMapConfig, MapConfig>();

            CreateMap<MapGenieMap, Map>()
            .ForMember(x => x.Id, _ => Guid.NewGuid())
            .ForMember(x => x.Name, x => x.MapFrom(c => c.Title))
            .ForMember(x => x.MapConfig, x => x.Ignore())
            .ForMember(x => x.Groups, x => x.Ignore())
            .ForMember(dest => dest.GameId, opt => opt.MapFrom((src, dest, _, context) =>
                context.Items["GameId"]));

            CreateMap<MapGenieGame, Game>()
             .ForMember(x => x.Id, _ => Guid.NewGuid())
             .ForMember(x => x.Maps, x => x.Ignore())
             .ForMember(x => x.Name, x => x.MapFrom(c => c.Title));


            CreateMap<MapConfig, MapConfigDto>()
             .ReverseMap();

            CreateMap<Category, CategoryDto>()
               .ReverseMap();

            CreateMap<Group, GroupDto>()
                .ReverseMap();

            CreateMap<Location, LocationDto>()
                .ReverseMap();

            CreateMap<Game, GameListItemDto>()
                .ReverseMap();

            CreateMap<Map, MapListItemDto>()
             .ReverseMap();
        }

        private static void MapGenieLocationAfterMap(MapGenieLocation src, Location dest, ResolutionContext context)
        {
            foreach (var srcMedia in src.Media)
                dest.AddMedia(context.Mapper.Map<Media>(srcMedia));
        }

        private static void MapGenieCategoryAfterMap(MapGenieCategory src, Category dest, ResolutionContext context)
        {
            var locations = ((List<MapGenieLocation>)context.Items["Locations"]).Where(x => x.CategoryId == src.Id);
            if (locations != null)
                foreach (var location in locations)
                    dest.AddLocation(context.Mapper.Map<Location>(location));
        }

        private static void MapGenieGropsAfterMap(MapGenieGroup src, Group dest, ResolutionContext context)
        {
            foreach (var srcCategory in src.Categories)
                dest.AddCategory(context.Mapper.Map<Category>(srcCategory));
        }
    }
}