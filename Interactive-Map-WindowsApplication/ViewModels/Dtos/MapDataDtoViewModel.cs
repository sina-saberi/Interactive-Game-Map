using Interactive_Map.Application.Services.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.ViewModels.Dtos
{
    public class MapDataDtoViewModel
    {
        public IEnumerable<LocationDtoViewModel> Locations { get; set; } = null!;
        public IEnumerable<GroupDtoViewModel> Groups { get; set; } = null!;
        public MapConfigDtoViewModel Config { get; set; } = null!;
    }
}
