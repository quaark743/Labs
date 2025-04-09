public class Disk : Circle
{
    public Disk(Point Center, double Radius) : base(Center, Radius)
    {
        Console.WriteLine($"Створено круг з центром у точці ({Center.X};{Center.Y}) і радіусом {Radius}");
    }
    public bool IsPointInside(Point point)
    {
        Console.WriteLine($"Перевірка: чи точка ({point.X};{point.Y}) належить кругу.");
        double dx = point.X - Center.X;
        double dy = point.Y - Center.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        return distance < Radius;
    }
    public override string ToString()
    {
        return $"Круг з центром у точці ({Center.X};{Center.Y}) та радіусом {Radius}";
    }

    public override bool Equals(object obj)
    {
        Console.WriteLine("Викликано Equals для круга.");
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        Console.WriteLine("Викликано GetHashCode для круга.");
        return base.GetHashCode();
    }
}

