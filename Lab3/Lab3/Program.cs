Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

int n = int.Parse(Console.ReadLine());

switch (n)
{
    case 1:
        Console.Write("Введіть значення x: ");

        string input = Console.ReadLine();

        if (double.TryParse(input, out double x1))
        {
            double y1 = Math.Pow(x1, 3) + 4 * Math.Pow(x1, 2) + x1 - 2;
            Console.WriteLine($"Значення у при заданому х: {y1}");
        }
        else
        {
            Console.WriteLine("Помилка: задане значення х не є числом типу double");
        }
        break;

    case 2:
        Console.Write("Введіть вартість 1 кг цукерок: ");

        string input1 = Console.ReadLine();

        Console.Write("Введіть вартість 1 кг печива: ");

        string input2 = Console.ReadLine();
        //a
        if (int.TryParse(input1, out int candy1) && int.TryParse(input2, out int cookie1))
        {
            int cost = (int)(0.3 * candy1) + (int)(0.4 * cookie1);
            Console.WriteLine($"Вартість покупки а: {cost}");
        }
        else
        {
            Console.WriteLine("Помилка: задане значення не є числом типу int");
        }
        //б
        if (int.TryParse(input1, out int candy2) && int.TryParse(input2, out int cookie2))
        {
            int cost = 3 * ((int)(1.8 * candy2) + (int)(2 * cookie2));
            Console.WriteLine($"Вартість покупки б: {cost}");
        }
        else
        {
            Console.WriteLine("Помилка: задане значення не є числом типу int");
        }
        break;

    case 3:
        bool isFalse = true;
        Console.Write("Введіть значення x: ");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Помилка: задане значення x не є числом.");
            isFalse = false;
        }

        Console.Write("Введіть значення a: ");
        if (!double.TryParse(Console.ReadLine(), out double a))
        {
            Console.WriteLine("Помилка: задане значення a не є числом.");
            isFalse = false;
        }

        if (x <= 2)
        {
            Console.WriteLine("Помилка: вираз під логарифмом повинен бути більшим за 0, тобто x > 2.");
            isFalse = false;
        }

        double sinA = Math.Sin(a);
        if (sinA == 0)
        {
            Console.WriteLine("Помилка: синус a не може дорівнювати 0, оскільки це призведе до ділення на нуль.");
            isFalse = false;
        }

        if (isFalse)
        {
            double y = Math.Log(Math.Pow(x, 3) - 8) + 1 / sinA;
            Console.WriteLine($"Значення y: {y}");
        }

        break;

    default:
        Console.WriteLine("Помилка: введіть значення від 1 до 3");
        break;
}




