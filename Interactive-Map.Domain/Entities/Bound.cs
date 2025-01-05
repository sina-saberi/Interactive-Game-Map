namespace Interactive_Map.Domain.Entities;

public class Bound
{
    public Bound(MinAndMax x, MinAndMax y)
    {
        X = x; Y = y;
    }

    public Bound() { }

    public MinAndMax X { get; set; } = null!;
    public MinAndMax Y { get; set; } = null!;
}