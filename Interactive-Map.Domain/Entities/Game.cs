using Interactive_Map.Domain.Base;
using System.Xml.Linq;

namespace Interactive_Map.Domain.Entities;

public class Game : EntityBase<Guid>
{
    public string Name { get; protected set; } = string.Empty;
    public string Slug { get; protected set; } = string.Empty;
    public bool Synced { get; protected set; }
    public DateTime? LastSynced { get; protected set; }
    public IEnumerable<Map>? Maps { get; protected set; }

    public Game(string name, string slug, bool synced, DateTime? lastSynced)
    {
        Name = name;
        Slug = slug;
        Synced = synced;
        LastSynced = lastSynced;
    }

    public Game(string name, string slug, bool synced, DateTime? lastSynced, ICollection<Map>? maps) :
        this(name, slug, synced, lastSynced)
    {
        Maps = maps;
    }

    public void Update(string? name, string? slug, bool? synced, DateTime? lastSynced)
    {
        Name = name ?? Name;
        Slug = slug ?? Slug;
        Synced = synced ?? Synced;
        LastSynced = lastSynced ?? LastSynced;
    }

    internal Game() { }
}