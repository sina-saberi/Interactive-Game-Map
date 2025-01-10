using Interactive_Map.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class MapConfigDto
    {
        public int InitialZoom { get; set; }
        public double StartLat { get; set; }
        public double StartLng { get; set; }
        public bool Overzoom { get; set; }
        public IEnumerable<TileSet>? TileSets { get; set; }
    }
}
