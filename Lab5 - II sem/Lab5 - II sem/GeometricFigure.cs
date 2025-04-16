abstract class GeometricFigure
{
    private string Color { get; set; }

    public GeometricFigure(string color)
    {
        Color = color;
    }

    public abstract double GetPerimeter();
    public abstract double GetArea();

    public virtual void Draw()
    {
        Console.WriteLine($"Колір: {Color}");
    }
}
