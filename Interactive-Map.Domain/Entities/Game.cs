using Interactive_Map.Domain.Base;
using System.Xml.Linq;

namespace Interactive_Map.Domain.Entities;

public class Game : EntityBase<Guid>
{
    private List<Map> _map = [];
    public string Name { get; protected set; } = string.Empty;
    public string Slug { get; protected set; } = string.Empty;
    public bool Synced { get; protected set; }
    public DateTime? LastSynced { get; protected set; }
    public IEnumerable<Map> Maps => _map.AsReadOnly();

    public Game(string name, string slug, bool synced, DateTime? lastSynced)
    {
        Name = name;
        Slug = slug;
        Synced = synced;
        LastSynced = lastSynced;
    }

    public void Update(string? name, string? slug, bool? synced, DateTime? lastSynced)
    {
        Name = name ?? Name;
        Slug = slug ?? Slug;
        Synced = synced ?? Synced;
        LastSynced = lastSynced ?? LastSynced;
    }

    public void Update(Game newGame) =>
        Update(newGame.Name, newGame.Slug, newGame.Synced, newGame.LastSynced);

    public Game AddMap(Map map)
    {
        _map.Add(map);
        return this;
    }

    internal Game() { }
}