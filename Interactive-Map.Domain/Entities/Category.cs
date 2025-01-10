using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Extensions;

namespace Interactive_Map.Domain.Entities;

public class Category : EntityBase<Guid>
{
    private List<Location> _locations = [];
    public Guid GroupId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Order { get; set; }

    public bool HasHeatmap { get; set; }

    public bool FeaturesEnabled { get; set; }

    public string DisplayType { get; set; } = null!;

    public bool IgnEnabled { get; set; }

    public bool IgnVisible { get; set; }

    public bool Visible { get; set; }

    public bool Premium { get; set; }

    public string? RefrenceId { get; set; }

    public Group? Group { get; set; }

    public IEnumerable<Location> Locations => _locations;

    public Category()
    {

    }

    public Category AddLocation(Location location)
    {
        _locations.Add(location);
        return this;
    }

    public Category(Guid groupId, string title, string? description, string icon, int order, bool hasHeatmap,
        bool featuresEnabled, string displayType, bool ignEnabled, bool ignVisible, bool visible, bool premium, string? refrenceId)
    {
        GroupId = groupId;
        Title = title;
        Description = description;
        Icon = icon;
        Order = order;
        HasHeatmap = hasHeatmap;
        FeaturesEnabled = featuresEnabled;
        DisplayType = displayType;
        IgnEnabled = ignEnabled;
        IgnVisible = ignVisible;
        Visible = visible;
        Premium = premium;
        RefrenceId = refrenceId;
    }

    public Category Update(string title, string? description, string icon, int order, bool hasHeatmap, bool featuresEnabled, string displayType, bool ignEnabled,
        bool ignVisible, bool visible, bool premium, string? refrenceId)
    {
        Title = title;
        Description = description;
        Icon = icon;
        Order = order;
        HasHeatmap = hasHeatmap;
        FeaturesEnabled = featuresEnabled;
        DisplayType = displayType;
        IgnEnabled = ignEnabled;
        IgnVisible = ignVisible;
        Visible = visible;
        Premium = premium;
        RefrenceId = refrenceId;
        return this;
    }


    public Category Update(Category category)
        => Update(
            category.Title, category.Description, category.Icon, category.Order,
            category.HasHeatmap, category.FeaturesEnabled, category.DisplayType,
            category.IgnEnabled, category.IgnVisible, category.Visible, category.Premium, category.RefrenceId
        );
}