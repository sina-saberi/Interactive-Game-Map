
namespace Interactive_Map.Domain.Entities;

public class TileSet
{
    public TileSet(string name, string path, string extension, string pattern, int minZoom,
        int maxZoom, int order, Dictionary<int, Bound>? bounds)
    {
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

    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public string Pattern { get; set; } = null!;

    public int MinZoom { get; set; }

    public int MaxZoom { get; set; }

    public int Order { get; set; }

    public Dictionary<int, Bound>? Bounds { get; set; }
}