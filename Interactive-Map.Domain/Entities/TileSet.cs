
namespace Interactive_Map.Domain.Entities;

public class TileSet
{
    public TileSet(int mapId, string name, string path, string extension, string pattern, int minZoom,
        int maxZoom, int order, Dictionary<int, Bound>? bounds)
    {
        MapId = mapId;
        Name = name;
        Path = path;
        Extension = extension;
        Pattern = pattern;
        MinZoom = minZoom;
        MaxZoom = maxZoom;
        Order = order;
        Bounds = bounds;
    }

    public TileSet()
    {
    }

    public int Id { get; set; }

    public int MapId { get; set; }

    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public string Pattern { get; set; } = null!;

    public int MinZoom { get; set; }

    public int MaxZoom { get; set; }

    public int Order { get; set; }

    public Dictionary<int, Bound>? Bounds { get; set; }
}