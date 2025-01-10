using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Extensions;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Interactive_Map.Domain.Entities;

public class Group : EntityBase<Guid>
{
    private List<Category> _categories = [];

    public Guid MapId { get; set; }
    public string Title { get; set; } = null!;
    public int Order { get; set; }
    public string Color { get; set; } = null!;
    public bool Expandable { get; set; }
    public string? RefrenceId { get; set; }
    public IEnumerable<Category> Categories => _categories.AsReadOnly();
    public Map? Map { get; set; }

    public Group Update(Group newGroup)
        => Update(newGroup.Title, newGroup.Order, newGroup.Color, newGroup.Expandable, newGroup.RefrenceId);

    public Group Update(string title, int order, string color, bool expandable, string? refrenceId)
    {
        Title = title;
        Order = order;
        Color = color;
        Expandable = expandable;
        RefrenceId = refrenceId;
        return this;
    }

    public Group AddCategory(Category newCategory)
    {
        _categories.Add(newCategory);
        return this;
    }

    public Group(string title, int order, string color, bool expandable, Guid mapId, string? refrenceId)
    {
        MapId = mapId;
        Title = title;
        Order = order;
        Color = color;
        Expandable = expandable;
        RefrenceId = refrenceId;
    }

    internal Group()
    {
    }
}