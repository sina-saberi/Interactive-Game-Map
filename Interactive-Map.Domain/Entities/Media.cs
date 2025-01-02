using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class Media : EntityBase<Guid>
{
    public Guid LocationId { get; set; }
    public string FileName { get; set; } = null!;
    public string MimeType { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Url { get; set; } = null!;
    public Location? Location { get; set; }

    public Media(string fileName, string mimeType, string title, string type, string url)
    {
        FileName = fileName;
        MimeType = mimeType;
        Title = title;
        Type = type;
        Url = url;
    }

    internal Media()
    {
    }
}