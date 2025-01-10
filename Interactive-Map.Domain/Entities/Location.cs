using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Enums;
using Interactive_Map.Domain.Extensions;

namespace Interactive_Map.Domain.Entities;

public class Location : EntityBase<Guid>
{
    private List<Media> _medias = [];
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public LocationType Type { get; set; } = LocationType.Server;
    public string? RefrenceId { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public IEnumerable<Media> Medias => _medias.AsReadOnly();
    public UserLocation? UserLocation { get; set; }


    internal Location()
    {
    }

    public Location(Guid categoryId, string title, string? description, double latitude, double longitude, LocationType type, string? refrenceId)
    {
        CategoryId = categoryId;
        Title = title;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
        Type = type;
        RefrenceId = refrenceId;
    }

    public Location Update(string title, string? description, double latitude, double longitude, LocationType type, string? refrenceId)
    {
        Title = title;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
        Type = type;
        RefrenceId = refrenceId;

        return this;
    }

    public Location Update(Location location) =>
        Update(location.Title, location.Description, location.Latitude, location.Longitude, location.Type, location.RefrenceId);

    public void AddLocationToCategory(Category category)
    {
        CategoryId = category.Id;
    }

    public void AddMedia(Media media)
    {
        _medias.Add(media);
    }
}