using AutoMapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map_WindowsApplication.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Mapper
{
    public class InterActiveMapsWindowsApplicationMapper : Profile
    {
        public InterActiveMapsWindowsApplicationMapper()
        {
            CreateMap<MapConfigDto, MapConfigDtoViewModel>().ReverseMap();
            CreateMap<CategoryDto, CategoryDtoViewModel>().ReverseMap();
            CreateMap<GroupDto, GroupDtoViewModel>().ReverseMap();
            CreateMap<LocationDto, LocationDtoViewModel>().ReverseMap();
            CreateMap<MapDataDto, MapDataDtoViewModel>().ReverseMap();

            CreateMap<GameListItemDto, GameListItemDtoViewModel>()
                .ReverseMap();
            CreateMap<MapListItemDto, MapListItemDtoViewModel>()
              .ReverseMap();
        }
    }
}
