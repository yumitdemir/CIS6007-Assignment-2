namespace Assignment_2;

public class Circle(int posX, int posY)
{
    public int X { get; } = posX;
    public int Y { get; } = posY;
    public bool IsPainted { get; private set; } = false;

    public void Paint()
    {
        IsPainted = true;
    }
}