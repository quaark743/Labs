using System;
using MyForest;
using TypesOfTree;

namespace NewForester
{
    class Forester
    {
        private Forest forest;

        public Forester(Forest forest)
        {
            this.forest = forest;
        }

        public void PlantTree(string type, int age, int count, bool hasPests)
        {
            try
            {
                if (type == "Дуб")
                {
                    Tree tree = new Oak(age, count, hasPests);
                    forest.AddTree(tree);
                }
                else if (type == "Сосна")
                {
                    Tree tree = new Pine(age, count, hasPests);
                    forest.AddTree(tree);
                }
                else if (type == "Береза")
                {
                    Tree tree = new Birch(age, count, hasPests);
                    forest.AddTree(tree);
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

        }

        public void CutOldTrees(int maxAge)
        {
            forest.RemoveTrees(maxAge);
        }

        public void CutTreesWithPests(bool hasPests)
        {
            forest.RemoveTrees(hasPests);
        }

        public void ShowForestInfo()
        {
            Console.WriteLine($"Розмір лісу: {forest.Area} гектарів");
            forest.ShowTrees();
        }
    }
}
