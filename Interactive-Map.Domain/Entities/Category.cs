using Interactive_Map.Domain.Base;

namespace Interactive_Map.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public Guid GroupId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Order { get; set; }

    public bool HasHeatmap { get; set; }

    public bool FeaturesEnabled { get; set; }

    public string DisplayType { get; set; } = null!;

    public bool IgnEnabled { get; set; }

    public bool IgnVisible { get; set; }

    public bool Visible { get; set; }

    public bool Premium { get; set; }

    public IEnumerable<Location>? Locations { get; set; }
    public Group? Group { get; set; }

    //public object Info { get; set; } = null!;

    //public object Template { get; set; } = null!;

    public Category(string title, string icon, string displayType, string description, IEnumerable<Location>? locations)
    {
        Title = title;
        Icon = icon;
        DisplayType = displayType;
        Description = description;
        Locations = locations;
    }

    public Category(string title, string icon, string displayType, string description)
    {
        Title = title;
        Icon = icon;
        DisplayType = displayType;
        Description = description;
    }

    internal Category() { }
}