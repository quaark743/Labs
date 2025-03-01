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
                Console.WriteLine("Введіть кількість рядків двовимірного масиву:");
                int n1 = int.Parse(Console.ReadLine());
                if (n1 <= 0)
                {
                    throw new Exception("Кількість рядків масиву повинна бути більше нуля");
                }

                Console.WriteLine("Введіть кількість стовбців двовимірного масиву:");
                int m1 = int.Parse(Console.ReadLine());
                if (m1 <= 0)
                {
                    throw new Exception("Кількість стовбців масиву повинна бути більше нуля");
                }

                Console.WriteLine("Введіть перше число діапазону: ");
                int a1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть друге число діапазону: ");
                int b1 = int.Parse(Console.ReadLine());
                if (a1 >= b1)
                {
                    throw new Exception("Числа діапазону повинні бути записані в порядку зростання");
                }

                int[,] Arr1 = new int[n1, m1];
                Random r1 = new Random();
                Console.Write("Згенерований масив: ");
                Console.WriteLine();
                for (int i = 0; i < Arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr1.GetLength(1); j++)
                    {
                        Arr1[i, j] = r1.Next(a1, b1);
                        Console.Write(Arr1[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                int sum = 0;
                int count = 0;
                for (int i = 0; i < Arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr1.GetLength(1); j++)
                    {
                        if (Arr1[i, j] % 2 != 0)
                        {
                            sum = sum + Arr1[i, j];
                            count++;
                        }
                    }
                }
                Console.WriteLine($"Середнє арифметичне непарних елементів масиву: {sum / count}");

                break;

            case 2:
                Console.WriteLine("Введіть кількість рядків двовимірного масиву:");
                int n2 = int.Parse(Console.ReadLine());
                if (n2 <= 0)
                {
                    throw new Exception("Кількість рядків масиву повинна бути більше нуля");
                }

                Console.WriteLine("Введіть кількість стовбців двовимірного масиву:");
                int m2 = int.Parse(Console.ReadLine());
                if (m2 <= 0)
                {
                    throw new Exception("Кількість стовбців масиву повинна бути більше нуля");
                }

                Console.WriteLine("Введіть перше число діапазону: ");
                int a2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть друге число діапазону: ");
                int b2 = int.Parse(Console.ReadLine());
                if (a2 >= b2)
                {
                    throw new Exception("Числа діапазону повинні бути записані в порядку зростання");
                }

                int[,] Arr2 = new int[n2, m2];
                Random r2 = new Random();
                Console.Write("Згенерований масив: ");
                Console.WriteLine();
                for (int i = 0; i < Arr2.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr2.GetLength(1); j++)
                    {
                        Arr2[i, j] = r2.Next(a2, b2);
                        Console.Write(Arr2[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                int[,] RotatedArray = Rotate180(Arr2);

                Console.WriteLine();
                Console.WriteLine("Перевернутий масив на 180 градусів:");
                for (int i = 0; i < RotatedArray.GetLength(0); i++)
                {
                    for (int j = 0; j < RotatedArray.GetLength(1); j++)
                    {
                        Console.Write(RotatedArray[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                int[,] Rotate180(int[,] arr)
                {
                    int a = arr.GetLength(0);
                    int b = arr.GetLength(1);
                    int[,] rotated = new int[a, b];

                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            rotated[a - 1 - i, b - 1 - j] = arr[i, j];
                        }
                    }

                    return rotated;
                }

                break;
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