using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        List<GeometricFigure> figures = new List<GeometricFigure>();

        // Коло
        Console.WriteLine("Введіть радіус кола:");
        double radius = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть колір кола:");
        string colorCircle = Console.ReadLine();
        figures.Add(new Circle(radius, colorCircle));

        // Квадрат
        Console.WriteLine("Введіть довжину сторони квадрата:");
        double sideLengthSquare = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть колір квадрата:");
        string colorSquare = Console.ReadLine();
        figures.Add(new Square(sideLengthSquare, colorSquare));

        // Ромб
        Console.WriteLine("Введіть довжину сторони ромба:");
        double sideLengthRombus = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть висоту ромба:");
        double heightRombus = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть колір ромба:");
        string colorRombus = Console.ReadLine();
        figures.Add(new Rombus(sideLengthRombus, heightRombus, colorRombus));

        // Паралелограм
        Console.WriteLine("Введіть довжину основи паралелограма:");
        double baseLengthParallelogram = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть довжину бічної сторони паралелограма:");
        double sideLengthParallelogram = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть висоту паралелограма:");
        double heightParallelogram = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть колір паралелограма:");
        string colorParallelogram = Console.ReadLine();
        figures.Add(new Parallelogram(baseLengthParallelogram, sideLengthParallelogram, heightParallelogram, colorParallelogram));

        // Відрізок
        Console.WriteLine("Введіть координати відрізка (x1, y1, x2, y2):");
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть колір відрізка:");
        string colorSegment = Console.ReadLine();
        figures.Add(new Segment(x1, y1, x2, y2, colorSegment));

        Console.WriteLine("---------------------------------------------------");
        foreach (var figure in figures)
        {
            figure.Draw();
            Console.WriteLine($"Периметр: {figure.GetPerimeter():F2}");
            Console.WriteLine($"Площа: {figure.GetArea():F2}");
            Console.WriteLine();
        }
    }
}
