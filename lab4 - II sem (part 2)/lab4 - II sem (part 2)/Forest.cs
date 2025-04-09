using System;
using System.Collections.Generic;
using System.Linq;
using TypesOfTree;

namespace MyForest
{
    class Forest
    {
        private List<Tree> trees = new List<Tree>();
        private double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        public Forest(double area)
        {
            Area = area;
        }
        public void AddTree(Tree tree)
        {
            trees.Add(tree);
            Console.WriteLine($"Додано {tree.Type} у ліс.");
        }

        public void RemoveTrees(int maxAge)
        {
            trees.RemoveAll(tree => tree.Age > maxAge);
            Console.WriteLine($"Зрубані всі дерева старші за {maxAge} років.");
        }

        public void RemoveTrees(bool hasPests)
        {
            trees.RemoveAll(tree => tree.HasPests == hasPests);
            Console.WriteLine($"Зрубані дерева зі шкідниками.");
        }

        public void ShowTrees()
        {
            if (trees.Count == 0)
            {
                Console.WriteLine("Ліс порожній.");
                return;
            }
            foreach (var tree in trees)
                tree.ShowInfo();
        }

        public void SortTreesByAge()
        {
            trees = trees.OrderBy(t => t.Age).ToList();
            Console.WriteLine("Дерева відсортовані за віком.");
        }

        public void SortTreesByType()
        {
            trees = trees.OrderBy(t => t.Type).ToList();
            Console.WriteLine("Дерева відсортовані за типом.");
        }
        public void SortTreesByCount()
        { 
            trees = trees.OrderBy(t => t.Count).ToList();
            Console.WriteLine("Дерева відсортовані за кількістю");
        }
    }
}
