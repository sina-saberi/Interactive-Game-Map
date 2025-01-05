using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Enums;

namespace Interactive_Map.Domain.Entities;

public class Location : EntityBase<Guid>
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public LocationType Type { get; set; }
    public IEnumerable<Media>? Media { get; set; }
    public UserLocation? UserLocation { get; set; }
    public Category? Category { get; set; }
    public Guid RefrenceId { get; set; }


    public Location(Guid refrenceId, string title, string? description, double latitude, double longitude, LocationType type, List<Media>? media) :
             this(title, description, latitude, longitude, type, media)
    {
        RefrenceId = refrenceId;
    }

    public Location(string title, string? description, double latitude, double longitude, LocationType type, IEnumerable<Media>? media) :
        this(title, description, latitude, longitude, type)
    {
        Media = media;
    }

    public Location(string title, string? description, double latitude, double longitude, LocationType type)
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