using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Enums;

namespace Interactive_Map.Domain.Entities;

public class Location : EntityBase<Guid>
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public LocationType Type { get; set; }
    public IEnumerable<Media>? Media { get; set; }
    public UserLocation? UserLocation { get; set; }
    public Category? Category { get; set; }

    //public object IgnPageId { get; set; } = null!;

    //public object Features { get; set; } = null!;
    //public List<object>? Tags { get; set; }
    //public object RegionId { get; set; } = null!;

    public Location(string title, string description, double latitude, double longitude, LocationType type, List<Media>? media)
    {
        Type = type;
        Title = title;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
        Media = media;
    }

    public Location(string title, string description, double latitude, double longitude, LocationType type)
    {
        Type = type;
        Title = title;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
    }

    internal Location()
    {
    }
}