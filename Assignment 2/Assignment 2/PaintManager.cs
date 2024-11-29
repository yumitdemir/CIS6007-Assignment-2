using System.Collections.Concurrent;

namespace Assignment_2;

public class PaintManager
{
    private ConcurrentQueue<Circle> circlesQueue;
    private Painter[] painters;

    public PaintManager(ConcurrentQueue<Circle> circles, int workerCount)
    {
        circlesQueue = circles;
        painters = new Painter[workerCount];

        for (int i = 0; i < workerCount; i++)
        {
            painters[i] = new Painter();
        }
    }

    public void Start()
    {
        Parallel.ForEach(painters, painter =>
        {
            while (!circlesQueue.IsEmpty)
            {
                if (circlesQueue.TryDequeue(out Circle circle))
                {
                    painter.Paint(circle);
                    Console.WriteLine($"Circle at ({circle.X}, {circle.Y}) painted by worker {Array.IndexOf(painters, painter)}");
                }
            }
        });
    }
}