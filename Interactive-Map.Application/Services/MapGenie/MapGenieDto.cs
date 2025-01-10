using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.MapGenie
{
    public class MapGenieDto
    {
        public IEnumerable<Domain.Entities.Group> Groups { get; set; }
    }
}
