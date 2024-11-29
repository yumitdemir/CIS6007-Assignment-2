using System.Collections.Concurrent;

namespace Assignment_2;

public class Painter
{

    private static readonly ConcurrentDictionary<Circle, bool> PaintedCircles = new();

    public void Paint(Circle circle)
    {
        if (!IsPainted(circle))
        {
            Thread.Sleep(20);
            circle.Paint();
            PaintedCircles.TryAdd(circle, true);
        }
    }

    private bool IsPainted(Circle circle)
    {
        return PaintedCircles.TryGetValue(circle, out bool isPainted) && isPainted;
    }
}