using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть координату X центру: ");
        double centerX = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть координату Y центру: ");
        double centerY = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть радіус круга: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        Point center = new Point(centerX, centerY);
        Disk disk = new Disk(center, radius);
        Console.WriteLine(); 


        Console.Write("Введіть новий радіус: ");
        double newRadius = Convert.ToDouble(Console.ReadLine());
        disk.ChangeRadius(newRadius);
        Console.WriteLine(disk);
        Console.WriteLine();

        Console.Write("Введіть новий центр (X): ");
        double newX = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть новий центр (Y): ");
        double newY = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть новий радіус: ");
        newRadius = Convert.ToDouble(Console.ReadLine());

        disk.SetSize(new Point(newX, newY), newRadius);
        Console.WriteLine();


        Console.Write("Введіть X точки для перевірки: ");
        double pointX = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть Y точки для перевірки: ");
        double pointY = Convert.ToDouble(Console.ReadLine());

        Point userPoint = new Point(pointX, pointY);
        bool isOnCircle = disk.IsPointOnCircle(userPoint);
        bool isInside = disk.IsPointInside(userPoint);

        if (userPoint.Equals(disk.Center))
            Console.WriteLine("Точка збігається з центром круга.");
            
        if (isOnCircle)
            Console.WriteLine($"{userPoint} лежить на межі кола.");
        else if (isInside)
            Console.WriteLine($"{userPoint} всередині круга.");
        else
            Console.WriteLine($"{userPoint} поза кругом.");
    }
}
