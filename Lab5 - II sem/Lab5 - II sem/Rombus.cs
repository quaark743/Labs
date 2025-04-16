class Rombus : Quadrilateral
{ 
    private double height;
    public double Height
    {
        get { return height; } 
        set
        {
            if (value <= 0)
                throw new ArgumentException("Висота повинна бути більшою за нуль.");
            if (value >= Sides[0].GetLength())
                throw new ArgumentException("Висота не може бути більшою або рівною довжині сторони ромба.");
            height = value;
        }
    }
    public Rombus(double SideLength, double height, string color)
        :base(CreateSides(SideLength, height, color), color)
    { 
        Height = height;
    }
    private static Segment[] CreateSides(double sideLength, double height, string color)
    {
        double xShift = Math.Sqrt(sideLength * sideLength - height * height);

        return new Segment[]
        {
        new Segment(0, 0, sideLength, 0, color),                           
        new Segment(sideLength, 0, sideLength - xShift, height, color),   
        new Segment(sideLength - xShift, height, -xShift, height, color), 
        new Segment(-xShift, height, 0, 0, color),                        
        };
    }
    public override double GetArea()
    {
        return Sides[0].GetLength() * Height;
    }
    public override void Draw()
    {
        Console.WriteLine($"Малюємо ромб з висотою {Height} і довжиною сторони {Sides[0].GetLength()}");
        base.Draw();
    }
}
