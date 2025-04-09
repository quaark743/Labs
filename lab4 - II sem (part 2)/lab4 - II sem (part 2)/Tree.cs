using System;

namespace TypesOfTree
{
    abstract class Tree
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private bool hasPests;
        public bool HasPests
        {
            get { return hasPests; }
            set { hasPests = value; }
        }
        public Tree(string type, int age, int count, bool hasPests)
        {
            Type = type;
            Age = age;
            Count = count;
            HasPests = hasPests;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Type} | Вік: {Age} років | Кількість: {Count} | Шкідники: {(HasPests ? "Так" : "Ні")}");
        }
    }

    class Oak : Tree
    {
        public Oak(int age, int count, bool hasPests) : base("Дуб", age, count, hasPests) { }
    }

    class Pine : Tree
    {
        public Pine(int age, int count, bool hasPests) : base("Сосна", age, count, hasPests) { }
    }

    class Birch : Tree
    {
        public Birch(int age, int count, bool hasPests) : base("Береза", age, count, hasPests) { }
    }
}
