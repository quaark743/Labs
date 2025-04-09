using System;
using System.Text;
using MyForest;
using NewForester;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Forest forest = new Forest(50); 
        Forester forester = new Forester(forest);

        while (true)
        {
            Console.WriteLine("--- Лісове меню ---");
            Console.WriteLine("1. Додати дерево");
            Console.WriteLine("2. Зрубати старі дерева");
            Console.WriteLine("3. Зрубати дерева з шкідниками"); 
            Console.WriteLine("4. Відсортувати дерева за типом");
            Console.WriteLine("5. Відсортувати дерева за віком");
            Console.WriteLine("6. Відсортувати дерева за кількістю");
            Console.WriteLine("7. Показати всі дерева");
            Console.WriteLine("8. Вийти");
            Console.Write("Виберіть опцію: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть тип дерева (Дуб/Сосна/Береза): ");
                    string type = Console.ReadLine();
                    Console.Write("Вік дерева: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість дерев: ");
                    int count = int.Parse(Console.ReadLine());
                    Console.Write("Чи є шкідники? (так/ні): ");
                    bool hasPests = Console.ReadLine().ToLower() == "так";

                    forester.PlantTree(type, age, count, hasPests);
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Write("Зрубати дерева старші за (років): ");
                    int maxAge = int.Parse(Console.ReadLine());
                    forester.CutOldTrees(maxAge);
                    Console.WriteLine();
                    break;
                case "3":
                    forester.CutTreesWithPests(true);
                    Console.WriteLine();
                    break;

                case "4":
                    forest.SortTreesByType();
                    Console.WriteLine();
                    break;

                case "5":
                    forest.SortTreesByAge();
                    Console.WriteLine();
                    break;

                case "6":
                    forest.SortTreesByCount();
                    Console.WriteLine();
                    break;

                case "7":
                    forester.ShowForestInfo();
                    Console.WriteLine();
                    break;

                case "8":
                    Console.WriteLine("Вихід...");
                    return;

                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
