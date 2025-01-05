using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class MapConfig : EntityBase<Guid>
{
    public MapConfig(Guid mapId, int initialZoom, double startLat, double startLng, bool overzoom,
        IEnumerable<TileSet>? tileSets)
    {
        MapId = mapId;
        InitialZoom = initialZoom;
        StartLat = startLat;
        StartLng = startLng;
        Overzoom = overzoom;
        TileSets = tileSets;
    }

    public void Update(int initialZoom, double startLat, double startLng, bool overzoom,
        IEnumerable<TileSet>? tileSets)
    {
        InitialZoom = initialZoom;
        StartLat = startLat;
        StartLng = startLng;
        Overzoom = overzoom;
        TileSets = tileSets;
    }

    public void Update(MapConfig newConfgi)
    {
        InitialZoom = newConfgi.InitialZoom;
        StartLat = newConfgi.StartLat;
        StartLng = newConfgi.StartLng;
        Overzoom = newConfgi.Overzoom;
        TileSets = newConfgi.TileSets;
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