Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

int a;
Console.Write("Введіть номер задачі: ");
a = int.Parse(Console.ReadLine());
switch (a)
{
    case 1:
    string input;
    do
    {
        try
        {
            int r1, r2;
            Console.Write("Введіть перше значення r1: ");
            r1 = int.Parse(Console.ReadLine());
            Console.Write("Введіть друге значення r2: ");
            r2 = int.Parse(Console.ReadLine());

            if (r1 <= r2)
            {
                throw new Exception("r1 має бути більше за r2");
            }
            else if (r1 <= 0 || r2 <= 0)
            {
                throw new Exception("Значення мають бути більше нуля");
            }

            Console.WriteLine($"Площа кола з радіусом {r1} = {Square(r1)}");
            Console.WriteLine($"Площа кола з радіусом {r2} = {Square(r2)}");
            Console.WriteLine($"Площа кільця = {Square(r1) - Square(r2)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        do
        {
            Console.WriteLine("Чи хочете продовжити виконання програми? (yes/no)");
            input = Console.ReadLine();
            if (input != "yes" && input != "no")
            {
                Console.WriteLine("Помилка: Введіть значення 'yes' або 'no'.");
            }
        }
        while (input.ToLower() != "yes" && input.ToLower() != "no");
        }
    while (input.ToLower() == "yes");

    double Square(int x)
    {
        return Math.PI * Math.Pow(x, 2);
    }
    break;
    case 2:
        do
        {
            try
            {
                int n;
                Console.Write("Введіть значення n: ");
                n = int.Parse(Console.ReadLine());

                if (n >= 10 && n <= 99)
                {
                    Console.WriteLine($"Десятки числа {n}: {FirstDigit(n)}");
                    Console.WriteLine($"Одиниці числа {n}: {SecondDigit(n)}");
                }
                else 
                {
                    throw new Exception("n має бути двоцифровим додатним числом");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            do
            {
                Console.WriteLine("Чи хочете продовжити виконання програми? (yes/no)");
                input = Console.ReadLine();
                if (input != "yes" && input != "no")
                {
                    Console.WriteLine("Помилка: Введіть значення 'yes' або 'no'.");
                }
            }
            while (input.ToLower() != "yes" && input.ToLower() != "no");
        }
        while (input.ToLower() == "yes");

        int FirstDigit(int x)
        {
            return x / 10;
        }
        int SecondDigit(int x)
        {
            return x % 10;
        }
        break;
}