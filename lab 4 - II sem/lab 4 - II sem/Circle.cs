public class Circle
{
    private Point center;
    public Point Center
    {
        get { return center; }
        set { center = value; }
    }
    private double radius;
    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public Circle (Point Center, double Radius)
    {
        Console.WriteLine($"Створено коло з центром у точці ({Center.X};{Center.Y}) і радіусом {Radius}");
        this.Center = Center;
        this.Radius = Radius;
    }
    public void SetSize(Point NewCenter, double NewRadius)
    {
        Console.WriteLine($"Задано розміри кола/круга з центром у точці ({NewCenter.X};{NewCenter.Y}) і радіусом {NewRadius}");
        Center = NewCenter;
        Radius = NewRadius;
    }
    public void ChangeRadius(double NewRadius)
    {
        Console.WriteLine($"Змінено радіус з {Radius} на {NewRadius}");
        Radius = NewRadius;
    }
    public bool IsPointOnCircle(Point point)
    {
        Console.WriteLine($"Перевірка: чи точка ({point.X};{point.Y}) належить колу.");
        double dx = point.X - Center.X;
        double dy = point.Y - Center.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        return (distance - Radius == 0);
    }
    public override string ToString()
    {
        return $"Коло з центром у точці ({Center.X};{Center.Y}) та радіусом {Radius}";
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("Викликано Equals для кола.");
        if (obj is Circle other)
            return Center.Equals(other.Center) && Radius == other.Radius;
        return false;
    }
    public override int GetHashCode()
    {
        Console.WriteLine("Викликано GetHashCode для кола.");
        return HashCode.Combine(Center, Radius);
    }
}
