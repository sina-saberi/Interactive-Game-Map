using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class Game : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public IEnumerable<Map>? Maps { get; set; }

    public Game(string name, string slug)
    {
        Name = name;
        Slug = slug;
    }
    public Game(string name, string slug, ICollection<Map>? maps)
    {
        Name = name;
        Slug = slug;
        Maps = maps;
    }
    internal Game() { }
}