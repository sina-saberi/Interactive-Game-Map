using Interactive_Map.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class MapDto
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public IList<Group>? Groups { get; set; }
        public MapConfig? MapConfig { get; set; }
    }
}
