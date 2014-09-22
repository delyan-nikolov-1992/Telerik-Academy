namespace LargeCollection
{
    using System;

    using Wintellect.PowerCollections;

    public class TestLargeCollection
    {
        private const int NumberOfProducts = 500000;
        private const int NumberOfSearches = 10000;

        public static void Main()
        {
            try
            {
                OrderedBag<Product> products = new OrderedBag<Product>();

                for (int i = 0; i < NumberOfProducts; i++)
                {
                    var product = new Product()
                    {
                        Name = "Product #" + i,
                        Price = i * 0.5
                    };

                    products.Add(product);
                }

                for (int i = 0; i < NumberOfSearches; i++)
                {
                    var firstTwentyProductsInRange = products.Range(
                        new Product { Price = i },
                        true,
                        new Product { Price = i + 3 },
                        true);

                    Console.WriteLine("Products with price between {0} and {1} inclusive", i, i + 3);

                    foreach (var product in firstTwentyProductsInRange)
                    {
                        Console.WriteLine(product.ToString());
                    }

                    Console.WriteLine();
                }
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}