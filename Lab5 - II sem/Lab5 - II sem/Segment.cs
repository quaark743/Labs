class Segment : GeometricFigure
{
    private double X1 { get; set; }
    private double Y1 { get; set; }
    private double X2 { get; set; }
    private double Y2 { get; set; }

    public Segment(double x1, double y1, double x2, double y2, string color)
        : base(color)
    {
        X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;
    }

    public double GetLength()
    {
        return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
    }

    public override double GetPerimeter() => GetLength();
    public override double GetArea() => 0;

    public override void Draw()
    {
        Console.WriteLine($"Малюємо відрізок з довжиною {GetLength()}");
        base.Draw();
    }
} 
