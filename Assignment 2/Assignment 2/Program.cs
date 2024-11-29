using System.Collections.Concurrent;
using System.Diagnostics;
using Assignment_2;

static ConcurrentQueue<Circle> GenerateCircles(int circleCount)
{
    ConcurrentQueue<Circle> circleQueue = new ConcurrentQueue<Circle>();
    for (int i = 0; i < circleCount; i++)
    {
        circleQueue.Enqueue(new Circle(i, i));
    }
    return circleQueue;
}

int[] workerNumbers = { 5, 20, 100 };
int totalCircleCount = 1001;

foreach (int workerCount in workerNumbers)
{
    ConcurrentQueue<Circle> circleQueue = GenerateCircles(totalCircleCount);
    PaintManager paintManager = new PaintManager(circleQueue, workerCount);
    Stopwatch timer = new Stopwatch();
    timer.Start();

    paintManager.Start();

    timer.Stop();
    long timeElapsed = timer.ElapsedMilliseconds;
    Console.WriteLine($"{workerCount} workers - {timeElapsed} ms");
    Console.WriteLine("All circles are painted.\n");
}