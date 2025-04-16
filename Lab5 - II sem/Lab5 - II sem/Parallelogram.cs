class Parallelogram : Quadrilateral
{
    private double BaseLength { get; set; }
    private double SideLength { get; set; }
    private double Height { get; set; }

    public Parallelogram(double baseLength, double sideLength, double height, string color)
        : base(CreateSides(baseLength, sideLength, height, color), color)
    {
        BaseLength = baseLength;
        SideLength = sideLength;
        Height = height;
    }

    private static Segment[] CreateSides(double baseLength, double sideLength, double height, string color)
    {
        if (baseLength <= 0 || sideLength <= 0 || height <= 0)
            throw new ArgumentException("Основи, бокова сторона та висота повинні бути більшими за нуль.");

        double shiftX = Math.Sqrt(sideLength * sideLength - height * height);

        return new Segment[]
        {
        new Segment(0, 0, baseLength, 0, color),                          
        new Segment(baseLength, 0, baseLength + shiftX, height, color),  
        new Segment(baseLength + shiftX, height, shiftX, height, color), 
        new Segment(shiftX, height, 0, 0, color),                        
        };
    }

    public override double GetArea()
    {
        return BaseLength * Height;
    }
    public override void Draw()
    {
        Console.WriteLine($"Малюємо паралелограм з основою {BaseLength}, бічною стороною {SideLength} і висотою {Height}");
        base.Draw();
    }
}
