namespace Articles
{
    using System;
    using Wintellect.PowerCollections;

    public class TestArticles
    {
        public const int itemsCount = 1000000;
        public const int searchesCount = 1000000;

        public static Random rand = new Random();

        public static void Main()
        {
            FillData();
        }

        private static void FillData()
        {
            OrderedMultiDictionary<int, Article> dict = new OrderedMultiDictionary<int, Article>(true);

            for (int i = 0; i < itemsCount; i++)
            {
                var price = rand.Next(1, itemsCount);
                dict.Add(price, new Article(GetRandomString(), GetRandomString(), GetRandomString(), price));
            }

            Console.WriteLine("Added {0} items.", itemsCount);

            for (int i = 0; i < searchesCount; i++)
            {
                dict.Range(rand.Next(0, itemsCount / 2), true, rand.Next(itemsCount / 2, itemsCount), true);
            }

            Console.WriteLine("Found {0} items in random price range.", searchesCount);
        }

        private static string GetRandomString()
        {
            return new string(((char)rand.Next(65, 91)), rand.Next(5, 12));
        }
    }
}