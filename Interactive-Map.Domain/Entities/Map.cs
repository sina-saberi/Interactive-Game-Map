using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Extensions;

namespace Interactive_Map.Domain.Entities;

public class Map : EntityBase<Guid>
{
    private List<Group> _groups = [];

    public Guid GameId { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public string Slug { get; protected set; } = string.Empty;
    public bool Synced { get; protected set; }
    public DateTime? LastSynced { get; protected set; }
    public IEnumerable<Group> Groups => _groups.AsReadOnly();
    public MapConfig? MapConfig { get; set; }
    public Game? Game { get; set; }

    public Map(string name, string slug, Guid gameId, bool synced, DateTime? lastSynced)
    {
        Name = name;
        Slug = slug;
        GameId = gameId;
        Synced = synced;
        LastSynced = lastSynced;
    }

    public void Update(string name, string slug, bool synced, DateTime? lastSynced)
    {
        Name = name;
        Slug = slug;
        Synced = synced;
        LastSynced = lastSynced;
    }

    public void Update(Map map) =>
        Update(map.Name, map.Slug, map.Synced, map.LastSynced);

    public Map AddGroup(Group group)
    {
        _groups.Add(group);
        return this;
    }

    public Map AddOrUpdateMapConfig(MapConfig config)
    {
        if (MapConfig == null) MapConfig = config;
        else MapConfig.Update(config);

        return this;
    }

    internal Map() { }
}