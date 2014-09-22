namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class OnlineMarket
    {
        private static HashSet<string> names = new HashSet<string>();
        private static HashSet<Product> products = new HashSet<Product>();

        public static void Main()
        {
            while (true)
            {
                string[] parameters = Console.ReadLine().Split(' ');

                switch (parameters[0])
                {
                    case "add":
                        AddProduct(parameters);
                        break;
                    case "filter":
                        FilterProducts(parameters);
                        break;
                    case "end":
                        return;
                    default:
                        break;
                }
            }
        }

        private static void AddProduct(string[] parameters)
        {
            var name = parameters[1];

            if (names.Contains(name))
            {
                Console.WriteLine("Error: Product {0} already exists", name);
                return;
            }

            names.Add(name);

            var price = double.Parse(parameters[2]);
            var type = parameters[3];

            var product = new Product(name, price, type);

            products.Add(product);

            Console.WriteLine("Ok: Product {0} added successfully", name);
        }

        private static void FilterProducts(string[] parameters)
        {
            var currentParam = parameters[2];

            if (currentParam == "type")
            {
                FilterByType(parameters);
            }
            else
            {
                FilterByPrice(parameters);
            }
        }

        private static void FilterByType(string[] parameters)
        {
            var searchedType = parameters[3];

            var result = products
                .Where(p => p.Type == searchedType)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Take(10)
                .ToList();

            if (result.Count() == 0)
            {
                Console.WriteLine("Error: Type {0} does not exists", searchedType);
            }
            else
            {
                Console.WriteLine("Ok: {0}", string.Join(", ", result));
            }
        }

        private static void FilterByPrice(string[] parameters)
        {
            var firstPrice = double.Parse(parameters[4]);

            if (parameters.Length == 7)
            {
                FilterByMinAndMaxPrice(firstPrice, double.Parse(parameters[6]));
            }
            else if (parameters[3] == "from")
            {
                FilterByMinPrice(firstPrice);
            }
            else
            {
                FilterByMaxPrice(firstPrice);
            }
        }

        private static void FilterByMinAndMaxPrice(double minPrice, double maxPrice)
        {
            var result = products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Take(10)
                .ToList();

            Console.WriteLine("Ok: {0}", string.Join(", ", result));
        }

        private static void FilterByMinPrice(double minPrice)
        {
            var result = products
                .Where(p => p.Price >= minPrice)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Take(10)
                .ToList();


            Console.WriteLine("Ok: {0}", string.Join(", ", result));
        }

        private static void FilterByMaxPrice(double maxPrice)
        {
            var result = products
                .Where(p => p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Take(10)
                .ToList();

            Console.WriteLine("Ok: {0}", string.Join(", ", result));
        }
    }

    public class Product
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString());
        }
    }

    public class NewProduct
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString());
        }
    }
}