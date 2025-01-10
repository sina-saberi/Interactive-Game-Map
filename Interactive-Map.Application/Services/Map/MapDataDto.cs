using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class MapDataDto
    {
        public IEnumerable<LocationDto> Locations { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
        public MapConfigDto Config { get; set; }

        public MapDataDto(IEnumerable<LocationDto> locations, IEnumerable<GroupDto> groups, MapConfigDto config)
        {
            Locations = locations;
            Groups = groups;
            Config = config;
        }
    }
}
