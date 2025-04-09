public class Point
{
    private double x;
    public double X
    {
        get { return x; }
        set { x = value; }
    }
    private double y;
    public double Y
    {
        get { return y; }
        set { y = value; }
    }
    public Point(double X, double Y)
    {
        Console.WriteLine("Створено точку");
        this.X = X; 
        this.Y = Y;
    }
    public override string ToString()
    {
        return $"Точка ({X};{Y})";
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("Викликано Equals для точки.");
        if (obj is Point other)
            return X == other.X && Y == other.Y;
        return false;
    }
    public override int GetHashCode()
    {
        Console.WriteLine("Викликано GetHashCode для точки.");
        return HashCode.Combine(X, Y);
    }
}
