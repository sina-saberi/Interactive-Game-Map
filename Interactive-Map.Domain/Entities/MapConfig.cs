using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class MapConfig : EntityBase<Guid>
{
    public MapConfig(int initialZoom, double startLat, double startLng, bool overzoom,
        List<TileSet>? tileSets)
    {
        InitialZoom = initialZoom;
        StartLat = startLat;
        StartLng = startLng;
        Overzoom = overzoom;
        TileSets = tileSets;
    }

    internal MapConfig()
    {
    }

    public Guid MapId { get; set; }

    public int InitialZoom { get; set; }

    public double StartLat { get; set; }

    public double StartLng { get; set; }

    public bool Overzoom { get; set; }
    public Map? Map { get; set; }

    public IEnumerable<TileSet>? TileSets { get; set; }
    //public object? Overlay { get; set; }
}