using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class Map : EntityBase<Guid>
{
    public Guid GameId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public IEnumerable<Group>? Groups { get; set; }
    public MapConfig? MapConfig { get; set; }
    public Game? Game { get; set; }

    public Map(string name, string slug)
    {
        Name = name;
        Slug = slug;
    }

    internal Map() { }
}