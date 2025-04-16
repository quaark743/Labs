class Circle : GeometricFigure
{
    private double radius;
    public double Radius
    {
        get { return radius; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Радіус не може бути від’ємним");
            radius = value;
        }
    }
    public Circle(double radius, string color)
        : base(color)
    {
        Radius = radius;
    }
    public override double GetPerimeter() => 2 * Math.PI * Radius;
    public override double GetArea() => Math.PI * Radius * Radius;
    public override void Draw()
    {
        Console.WriteLine($"Малюємо коло з радіусом {Radius}");
        base.Draw();
    }

}

