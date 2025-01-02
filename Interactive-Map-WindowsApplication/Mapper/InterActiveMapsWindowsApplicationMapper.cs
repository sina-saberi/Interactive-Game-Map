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
            CreateMap<GameListItemDto, GameListItemDtoViewModel>()
                .ReverseMap();
            CreateMap<MapListItemDto, MapListItemDtoViewModel>()
              .ReverseMap();
        }
    }
}
