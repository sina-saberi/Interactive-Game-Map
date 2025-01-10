using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.MapGenie.Dto
{
    public class DGGroup
    {
        public Guid MapId { get; set; }
        public string Title { get; set; } = null!;
        public int Order { get; set; }
        public string Color { get; set; } = null!;
        public bool Expandable { get; set; }
        public IList<DGCategory> Categories { get; set; } = [];

        public DGGroup(string title, int order, string color, bool expandable, List<DGCategory> categories)
        {
            Title = title;
            Order = order;
            Color = color;
            Expandable = expandable;
            Categories = categories;
        }
    }
}
