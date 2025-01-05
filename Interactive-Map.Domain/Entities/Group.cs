using Interactive_Map.Domain.Base;
using System.Drawing;

namespace Interactive_Map.Domain.Entities;

public class Group : EntityBase<Guid>
{
    public Guid MapId { get; set; }
    public string Title { get; set; } = null!;
    public int Order { get; set; }
    public string Color { get; set; } = null!;
    public bool Expandable { get; set; }
    public IEnumerable<Category> Categories { get; set; } = [];
    public Map? Map { get; set; }

    public void Update(Group newGroup)
    {
        Title = newGroup.Title;
        Order = newGroup.Order;
        Color = newGroup.Color;
        Expandable = newGroup.Expandable;
        Categories = newGroup.Categories;
    }

    public Group(string title, int order, string color, bool expandable, List<Category>? categories)
    {
        Title = title;
        Order = order;
        Color = color;
        Expandable = expandable;
        Categories = categories;
    }
    public Group(string title, int order, string color, bool expandable)
    {
        Title = title;
        Order = order;
        Color = color;
        Expandable = expandable;
    }

    internal Group()
    {
    }
}