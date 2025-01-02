using AutoMapper;
using Interactive_Map.Domain.Entities;
using Interactive_Map.WebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MapGenieGame, Game>()
                .ForMember(x => x.Id, _ => Guid.NewGuid())
                .ForMember(x => x.Name, x => x.MapFrom(c => c.Title))
                .ForMember(x => x.Maps, x => x.Ignore());//TODO:Check this later
        }
    }
}
