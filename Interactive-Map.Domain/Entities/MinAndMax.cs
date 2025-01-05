namespace Interactive_Map.Domain.Entities;

public class MinAndMax
{
    public MinAndMax(int max, int min)
    {
        Max = max;
        Min = min;
    }

    public MinAndMax() { }

    public int Max { get; set; }

    public int Min { get; set; }
}