Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
string input;
do
{
    try
    {
        Console.Write("Введіть ціле число N: ");
        int N = int.Parse(Console.ReadLine());

        if (N <= 0)
        {
            Console.WriteLine("Помилка: Значення N повинно бути цілим числом більше нуля");
            return;
        }

        Console.WriteLine("Піфагорові трійки:");

        bool found = false;

        for (int c = 1; c < N; c++)
        {
            for (int a = 1; a < c; a++)
            {
                for (int b = a; b < c; b++)
                {
                    if (a * a + b * b == c * c)
                    {
                        Console.WriteLine($"{a}, {b}, {c}");
                        found = true;
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Не знайдено жодної піфагорової трійки для введеного N.");
        }
    }

    catch (FormatException)
    {
        Console.WriteLine("Помилка: Введіть коректне значення N");
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Сталася помилка: {ex.Message}");
    }
    do
    {
        Console.WriteLine("Бажаєте продовжити? (yes/no)");
        input = Console.ReadLine().ToLower();

        if (input != "yes" && input != "no")
        {
            Console.WriteLine("Помилка: Введіть значення 'yes' або 'no'.");
        }
    }
    while (input != "yes" && input != "no");
}
while (input == "yes");
    


