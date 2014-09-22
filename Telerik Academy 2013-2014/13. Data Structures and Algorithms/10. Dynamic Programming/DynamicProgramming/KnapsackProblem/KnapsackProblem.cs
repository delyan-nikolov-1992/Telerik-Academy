namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnapsackProblem
    {
        private const int KnapsackCapacity = 10;

        private static Product[] products = new Product[] 
        { 
            new Product("beer", 3, 2),
            new Product("vodka", 8, 12),
            new Product("cheese", 4, 5),
            new Product("nuts", 1, 4),
            new Product("ham", 2, 3),
            new Product("whiskey", 8, 13)
        };

        private static int[,] matrix = new int[products.Length, KnapsackCapacity + 1];
        private static int[,] picks = new int[products.Length, KnapsackCapacity + 1];

        public static void Main()
        {
            int result = FillKnapsack(products.Length - 1, KnapsackCapacity);
            IList<Product> takenProducts = TakenProducts();

            Console.WriteLine("Optimal solution:");
            Console.WriteLine(string.Join(" + ", takenProducts));
            Console.WriteLine("weight = {0}", takenProducts.Sum(p => p.Weight));
            Console.WriteLine("cost = {0}", result);
        }

        private static int FillKnapsack(int index, int capacity)
        {
            int takenProducts = 0;
            int notTakenProducts = 0;

            if (matrix[index, capacity] != 0)
            {
                return matrix[index, capacity];
            }

            if (index == 0)
            {
                if (products[0].Weight <= capacity)
                {
                    picks[index, capacity] = 1;
                    matrix[index, capacity] = products[0].Cost;

                    return products[0].Cost;
                }
                else
                {
                    picks[index, capacity] = -1;
                    matrix[index, capacity] = 0;

                    return 0;
                }
            }

            if (products[index].Weight <= capacity)
            {
                takenProducts = products[index].Cost + FillKnapsack(index - 1, capacity - products[index].Weight);
            }

            notTakenProducts = FillKnapsack(index - 1, capacity);
            matrix[index, capacity] = Math.Max(takenProducts, notTakenProducts);

            if (takenProducts > notTakenProducts)
            {
                picks[index, capacity] = 1;
            }
            else
            {
                picks[index, capacity] = -1;
            }

            return matrix[index, capacity];
        }

        private static IList<Product> TakenProducts()
        {
            IList<Product> takenProducts = new List<Product>();
            int capacity = KnapsackCapacity;
            int index = products.Length - 1;

            while (index >= 0)
            {
                if (picks[index, capacity] == 1)
                {
                    takenProducts.Add(products[index]);
                    capacity -= products[index].Weight;
                    index--;
                }
                else
                {
                    index--;
                }
            }

            return takenProducts;
        }
    }
}