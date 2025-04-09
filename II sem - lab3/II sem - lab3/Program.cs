using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть перший многочлен (у форматі 'коеф степінь', наприклад: 3 2 для 3x^2). Напишіть 'end' для завершення:");
        Polynomial p1 = ReadPolynomialFromConsole();
        SavePolynomialToJson(p1, "poly1.json");
        Polynomial loaded1 = LoadPolynomialFromJson("poly1.json");
        Console.WriteLine("Многочлен, прочитаний із JSON: " + loaded1);

        Console.WriteLine("Введіть другий многочлен:");
        Polynomial p2 = ReadPolynomialFromConsole();
        SavePolynomialToJson(p2, "poly2.json");
        Polynomial loaded2 = LoadPolynomialFromJson("poly2.json");
        Console.WriteLine("Многочлен, прочитаний із JSON: " + loaded2);
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Сума: " + Polynomial.Add(p1, p2));
        Console.WriteLine("Різниця: " + Polynomial.Subtract(p1, p2));
        Console.WriteLine("Добуток: " + Polynomial.Multiply(p1, p2));

        var (quotient, remainder) = Polynomial.Divide(p1, p2);
        Console.WriteLine("Частка: " + quotient);
        Console.WriteLine("Остача: " + remainder);

        Console.WriteLine("Перший многочлен містить одночлен 2x^3? " + p1.Contains(new Monomial(2, 3)));
        Console.WriteLine("Другий многочлен містить одночлен 2x^3? " + p2.Contains(new Monomial(2, 3)));

        Console.WriteLine("Перший многочлен = другому? " + Polynomial.AreEqual(p1, p2));

    }
    static Polynomial ReadPolynomialFromConsole()
    {
        var polynomial = new List<Monomial>();

        while (true)
        {
            string line = Console.ReadLine();

            if (line.ToLower() == "end")
                break;

            var parts = line.Split();

            if (parts.Length != 2 ||
                !double.TryParse(parts[0], out double coefficient) ||
                !int.TryParse(parts[1], out int degree))
            {
                Console.WriteLine("Невірний формат. Введіть як 'коеф степінь', наприклад: 4 2");
                continue;
            }

            polynomial.Add(new Monomial(coefficient, degree));
        }

        return new Polynomial(polynomial);
    }
    public static void SavePolynomialToJson(Polynomial poly, string filePath)
    {
        string json = JsonConvert.SerializeObject(poly, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Многочлен збережено у файл: " + filePath);
    }
    public static Polynomial LoadPolynomialFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено!");
            return null;
        }

        string json = File.ReadAllText(filePath);
        Polynomial poly = JsonConvert.DeserializeObject<Polynomial>(json);
        Console.WriteLine("Многочлен завантажено з файлу: " + filePath);
        return poly;
    }
}




