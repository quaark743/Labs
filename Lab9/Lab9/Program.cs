Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string input;
do
{
    try
    {
        Console.WriteLine("Введіть номер задачі: ");
        int number = int.Parse(Console.ReadLine());
        if (number != 1 && number != 2)
        {
            throw new Exception("Введіть номер задачі 1 або 2");
        }
        switch (number)
        {
            case 1:
                {
                    string inputFilePath = "D:\\Programs\\С#\\InputLab9.txt";
                    string outputFilePath = "D:\\Programs\\С#\\OutputLab9.txt";

                    Console.WriteLine("Введіть довжину слова:");
                    int k = int.Parse(Console.ReadLine());

                    Console.WriteLine("Запишіть слова у файл:");
                    using (StreamWriter writer = new StreamWriter(inputFilePath))
                    {
                        writer.WriteLine(Console.ReadLine());
                    }

                    using (StreamReader reader = new StreamReader(inputFilePath))
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        string[] words = reader.ReadToEnd().Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in words)
                        {
                            if (word.Length == k)
                            {
                                writer.WriteLine(word);
                            }
                        }
                    }

                    Console.WriteLine($"Слова довжини {k} були записані у файл, який розташовується в {outputFilePath}.");
                    break;
                }

            case 2:
            {
                string sourceFolder = "D:\\Programs\\С#\\SourceFolder";
                string targetFolder = "D:\\Programs\\С#\\TargetFolder";
                string logFilePath = Path.Combine(targetFolder, "FileMappingLog.txt");

                Console.WriteLine("Оберіть операцію: 1 - перейменування файлів, 2 - відновлення назв файлів, 3 - видалення папки TargetFolder.");
                int operation = int.Parse(Console.ReadLine());

                if (operation == 1)
                {
                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }

                    string[] files = Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories);

                    using (StreamWriter logWriter = new StreamWriter(logFilePath, false))
                    {
                        foreach (string file in files)
                        {
                            string originalFileName = Path.GetFileName(file);
                            string fileName = Path.GetFileNameWithoutExtension(file);
                            string fileExtension = Path.GetExtension(file);

                            if (fileName.Length >= 5)
                            {
                                fileName = fileName.Remove(4, 1).Remove(2, 1);
                            }
                            else if (fileName.Length >= 3)
                            {
                                fileName = fileName.Remove(2, 1);
                            }

                            if (fileExtension.Length > 1)
                            {
                                fileExtension = fileExtension.Substring(0, fileExtension.Length - 1);
                            }

                            string newFileName = fileName + fileExtension;
                            string newFilePath = Path.Combine(targetFolder, newFileName);

                            File.Copy(file, newFilePath, true);

                            logWriter.WriteLine($"{newFileName}|{originalFileName}");
                        }
                    }
                    Console.WriteLine("Файли перейменовано");
                }
                else if (operation == 2)
                {
                    RestoreOriginalFileNames(targetFolder);
                }
                else if (operation == 3)
                {
                    try
                    {
                        if (Directory.Exists(targetFolder))
                        {
                            Directory.Delete(targetFolder, true);
                            Console.WriteLine($"Папка {targetFolder} успішно видалена.");
                        }
                        else
                        {
                            Console.WriteLine($"Папка {targetFolder} не існує.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка при видаленні папки: {ex.Message}");
                    }
                }
                break;

            }
        }
        void RestoreOriginalFileNames(string targetFolder)
        {
            string logFilePath = Path.Combine(targetFolder, "FileMappingLog.txt");

            if (!File.Exists(logFilePath))
            {
                Console.WriteLine($"Лог-файл {logFilePath} не знайдено. Відновлення неможливе.");
                return;
            }

            string[] mappings = File.ReadAllLines(logFilePath);

            foreach (string mapping in mappings)
            {
                string[] parts = mapping.Split('|');

                string modifiedFileName = parts[0];
                string originalFileName = parts[1];

                string modifiedFilePath = Path.Combine(targetFolder, modifiedFileName);
                string originalFilePath = Path.Combine(targetFolder, originalFileName);

                File.Move(modifiedFilePath, originalFilePath);
                Console.WriteLine($"Файл {modifiedFileName} відновлено до {originalFileName}");
            }
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