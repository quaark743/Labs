abstract class Quadrilateral : GeometricFigure
{
    private Segment[] sides = new Segment[4];
    public Segment[] Sides 
    { 
        get { return sides; }
        set { sides = value; }
    }

    public Quadrilateral(Segment[] sides, string color)
        : base(color)
    {
        if (sides.Length != 4) throw new ArgumentException("Повинно бути 4 сторони");
        this.sides = sides;
    }

    public override double GetPerimeter()
    {
        return Sides.Sum(s => s.GetLength());
    }
    public override void Draw()
    {
        Console.WriteLine($"Малюємо чотирикутник");
        base.Draw();
    }
}

