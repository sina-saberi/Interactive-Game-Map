using AutoMapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map.Application.Services.Map;
using Interactive_Map.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Mapper
{
    internal class InteractiveMapApplicationMapperProfile : Profile
    {
        public InteractiveMapApplicationMapperProfile()
        {
            CreateMap<Game, GameListItemDto>()
                .ReverseMap();
            CreateMap<Map, MapListItemDto>()
             .ReverseMap();
            CreateMap<Map, MapDto>()
              .ReverseMap();
        }
    }
}
