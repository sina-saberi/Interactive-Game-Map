using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class Map : EntityBase<Guid>
{
    public Guid GameId { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public string Slug { get; protected set; } = string.Empty;
    public IEnumerable<Group>? Groups { get; set; }
    public MapConfig? MapConfig { get; set; }
    public Game? Game { get; set; }

    public Map(string name, string slug, Guid gameId)
    {
        Name = name;
        Slug = slug;
        GameId = gameId;
    }

    public void Update(string name, string slug)
    {
        Name = name;
        Slug = slug;
    }

    internal Map() { }
}