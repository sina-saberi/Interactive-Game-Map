using Interactive_Map.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Domain.Entities
{
    public class UserLocation : EntityBase<Guid>
    {
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool Marked { get; set; }
        public bool Checked { get; set; }
    }
}
