﻿using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class Media : EntityBase<Guid>
{
    public Guid LocationId { get; set; }
    public string FileName { get; set; } = null!;
    public string MimeType { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Type { get; set; } = null!;
    public Location? Location { get; set; }

    public Media(string fileName, string mimeType, string title, string type)
    {
        FileName = fileName;
        MimeType = mimeType;
        Title = title;
        Type = type;
    }

    public Media Update(string fileName, string mimeType, string title, string type)
    {
        FileName = fileName;
        MimeType = mimeType;
        Title = title;
        Type = type;

        return this;
    }

    public Media Update(Media media) => Update(media.FileName, media.MimeType, media.Title, media.Type);

    internal Media()
    {
    }
}