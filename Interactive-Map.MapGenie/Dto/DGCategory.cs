using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.MapGenie.Dto
{
    public class DGCategory
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public int Order { get; set; }

        public bool HasHeatmap { get; set; }

        public bool FeaturesEnabled { get; set; }

        public string DisplayType { get; set; } = null!;

        public bool IgnEnabled { get; set; }

        public bool IgnVisible { get; set; }

        public bool Visible { get; set; }

        public bool Premium { get; set; }

        public IList<DGLocation> Locations { get; set; } = [];
        public DGCategory(string title, string icon, string displayType, string? description, IEnumerable<DGLocation> locations)
        {
            Title = title;
            Icon = icon;
            DisplayType = displayType;
            Description = description;
            Locations = locations.ToList();
        }
    }
}
