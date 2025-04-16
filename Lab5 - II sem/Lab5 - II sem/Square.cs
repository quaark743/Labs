class Square : Quadrilateral
{
    public Square(double sideLength, string color)
        : base(CreateSides(sideLength, color), color) {}
    private static Segment[] CreateSides(double length, string color)
    {
        return new Segment[]
        {
            new Segment(0, 0, length, 0, color),
            new Segment(length, 0, length, length, color),
            new Segment(length, length, 0, length, color),
            new Segment(0, length, 0, 0, color),
        };
    }
    public override double GetArea()
    {
        double side = Sides[0].GetLength();
        return side * side;
    }
    public override void Draw()
    {
        Console.WriteLine($"Малюємо квадрат з довжиною сторони {Sides[0].GetLength()}");
        base.Draw();
    }
}
