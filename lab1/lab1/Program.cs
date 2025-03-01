using Newtonsoft.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

string input;
do
{
    try
    {
        Console.Write("Введіть номер задачі: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                {
                    Console.Write("Введіть число x: ");
                    int x = int.Parse(Console.ReadLine());

                    Console.Write("Введіть довжину списка: ");
                    int length = int.Parse(Console.ReadLine());  

                    Console.WriteLine("Введіть список цілих чисел (через пробіл):");
                    string s = Console.ReadLine();
                    string[] parts = s.Split(' ');

                    List<int> list = new List<int>();

                    foreach (string part in parts)
                    {
                        list.Add(int.Parse(part));
                    }

                    int index = list.IndexOf(x);
                    int last = list.Count - 1;
                    if (index == -1)
                    {
                        throw new Exception("Число x не знайдено в списку");
                    }
                    if (index != 0 && index != last)
                    {
                        list.Reverse(0, index);
                        list.Reverse(index + 1, last - index);
                    }
                    else if (index == 0)
                    {
                        list.Reverse(1, last);
                    }
                    else 
                    {
                        list.Reverse(0, last - 1);
                    }

                    Console.WriteLine("Результат: " + string.Join(" ", list));
                    break;
                }
            case 2:
                {
                    Dictionary<int, string> dict = ReadDictionaryFromConsole();
                    Console.Write("Введіть мінімальний ключ (число): ");
                    if (int.TryParse(Console.ReadLine(), out int MinKey));
                    {
                        Console.WriteLine(Filter(dict, MinKey));
                    }

                    Dictionary<int, string> ReadDictionaryFromConsole()
                    {
                        Dictionary<int, string> dictionary = new Dictionary<int, string>();
                        Console.WriteLine("Введіть словник (формат: ключ значення). Напишіть 'end' в кінці:");

                        while (true)
                        {
                            string input = Console.ReadLine();
                            if (input.ToLower() == "end")
                                break;

                            string[] parts = input.Split(' ', 2);
                            if (parts.Length == 2 && int.TryParse(parts[0], out int key))
                            {
                                dictionary[key] = parts[1];
                            }
                            else
                            {
                                throw new Exception("Неправильний ввід. Формат: ключ значення");
                            }
                        }
                        return dictionary;
                    }
                    string Filter(Dictionary<int, string> dict, int minKey)
                    {
                        Dictionary<int, string> filtered = new Dictionary<int, string>();

                        foreach (var i in dict)
                        {
                            if (i.Key >= minKey)
                            {
                                filtered[i.Key] = i.Value;
                            }
                        }
                        return filtered.Count > 0 ? JsonConvert.SerializeObject(filtered, Formatting.Indented) : "null";
                    }
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Введіть число (0-9): ");
                    int D = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введіть послідовність цілих чисел: ");
                    string s = Console.ReadLine();
                    string[] Array = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int[] A = new int[Array.Length];
                    for (int i = 0; i < Array.Length; i++)
                    {
                        A[i] = int.Parse(Array[i]);
                    }

                    var result = A
                                .Where(x => x > 0 && x % 10 == D)
                                .Reverse()
                                .Distinct()
                                .Reverse()
                                .ToArray();
                    foreach (int i in result)
                    {
                        Console.Write(i + " ");
                    }
                    break;
                }
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