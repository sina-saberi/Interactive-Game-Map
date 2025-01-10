using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.MapGenie.Dto
{
    public class DGLocation
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IList<DGMedia> Media { get; set; } = [];
        public Guid RefrenceId { get; set; }

        public DGLocation(string title, string? description, double latitude, double longitude, List<DGMedia> media)
        {
            Title = title;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            Media = media;
        }
    }
}
