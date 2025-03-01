using System.Text.RegularExpressions;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string input;
do
{
    try
    {
        Console.WriteLine("Введіть номер задачі(1/2): ");
        int q = int.Parse(Console.ReadLine());
        if (q != 1 && q != 2)
        {
            throw new Exception("Введіть номер задачі 1 або 2");
        }

        switch (q)
        {
            case 1:
                {
                    Console.WriteLine("Введіть бажаний рядок: ");
                    string str = Console.ReadLine();

                    Console.WriteLine($"Сума всіх цифр рядка: {SumOfDigits(str)}");
                    Console.WriteLine($"Послідовність символів до першої крапки з комою: {Sequence(str)}"); 

                    break;
                }
            case 2:
                {
                    Console.WriteLine("Введіть бажаний рядок: ");
                    string str = Console.ReadLine();
                    bool valid = BracketsValid(str);
                    if (valid)
                    {
                        Console.WriteLine("Рядок є валідним");
                    }
                    else if (!valid)
                    {
                        Console.WriteLine("Рядок не є валідним");
                    }
                    break;
                }
        }
        int SumOfDigits(string s)
        {
            int sum = 0;

            foreach (char i in s)
            {
                if (char.IsDigit(i))
                {
                    sum += int.Parse(i.ToString());
                }
            }
            return sum;
        }
        string Sequence(string s)
        {
            return s.Substring(0, s.IndexOf(';'));
        }
        bool BracketsValid(string s)
        {
            s = Regex.Replace(s, @"[^\(\)\[\]\{\}]", "");

            Regex MyReg = new Regex(@"\(\)|\{\}|\[\]");

            while (MyReg.IsMatch(s))
            {
                s = MyReg.Replace(s, "");
            }

            return s.Length == 0;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Виникла помилка: {ex.Message}");
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