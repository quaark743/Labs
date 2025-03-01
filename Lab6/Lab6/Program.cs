Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

string input;
do
{
    try
    {

        Console.WriteLine("Введіть довжину масиву:");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            throw new Exception("Довжина масиву повинна бути більше нуля");
        }
        Console.WriteLine("Введіть перше число діапазону: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть друге число діапазону: ");
        int b = int.Parse(Console.ReadLine());
        if (a >= b)
        {
            throw new Exception("Числа діапазону повинні бути записані в порядку зростання");
        }

        int[] Arr = new int[n];
        Random r = new Random();
        Console.Write("Згенерований масив: ");
        for (int i = 0; i < Arr.Length; i++)
        {
            Arr[i] = r.Next(a, b);
            Console.Write(Arr[i] + " ");
        }
        int MaxIndex = Array.IndexOf(Arr, Max(Arr));
        int MinIndex = Array.IndexOf(Arr, Min(Arr));

        int start = Math.Min(MinIndex, MaxIndex);
        int end = Math.Max(MinIndex, MaxIndex);

        int[] result = Rev(Arr, start, end);
        Console.WriteLine();
        Console.Write("Перевернутий масив між максимальним і мінімальни: ");
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }

        Reverse(Arr);
        Console.WriteLine();
        Console.Write("Перевернутий масив додатніх послідовностей: ");
        for (int i = 0; i < Arr.Length; i++)
        {
            Console.Write(Arr[i] + " ");
        }
        int[] Rev(int[] arr, int start, int end)
        {

            int length = end - start + 1;
            int[] reversedArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                reversedArray[i] = arr[end - i];
            }
            return reversedArray;
        }
        void Reverse(int[] arr)
        {
            int start = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0 && start == -1)
                {
                    start = i;
                }

                if ((arr[i] < 0 || i == arr.Length - 1) && start != -1)
                {
                    int end = (arr[i] < 0) ? i - 1 : i;
                    if (end - start + 1 >= 2)
                    {
                        int[] reversedArray = Rev(arr, start, end);

                        for (int j = 0; j < reversedArray.Length; j++)
                        {
                            arr[start + j] = reversedArray[j];
                        }
                    }

                    start = -1;
                }
            }
        }
        int Max(int[] arr)
        {
            int max = arr[0];
            foreach (int i in arr)
            {
                if (i > max)
                    max = i;
            }
            return max;
        }
        int Min(int[] arr)
        {
            int min = arr[0];
            foreach (int i in arr)
            {
                if (i < min)
                    min = i;
            }
            return min;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Виникла помилка: {ex.Message}"); 
    }
    Console.WriteLine();
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


