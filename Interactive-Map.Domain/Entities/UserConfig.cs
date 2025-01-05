using Interactive_Map.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Domain.Entities
{
    public class UserConfig : EntityBase<Guid>
    {
        public Dictionary<string, string>? SpecialGameLinks { get; set; }
        public Dictionary<string, string>? SpecialMapLinks { get; set; }
    }
}
