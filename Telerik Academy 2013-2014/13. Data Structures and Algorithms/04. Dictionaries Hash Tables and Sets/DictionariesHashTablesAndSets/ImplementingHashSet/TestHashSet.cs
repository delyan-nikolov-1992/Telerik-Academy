namespace ImplementingHashSet
{
    using System;

    public class TestHashSet
    {
        public static void Main()
        {
            var set1 = new HashSet<string>();
            var set2 = new HashSet<string>();

            set1.Add("Doncho");
            set1.Add("Ivaylo");
            set1.Add("Niki");

            set2.Add("Niki");
            set2.Add("Evlogii");

            Console.WriteLine(set1);
            Console.WriteLine(set2);

            Console.WriteLine(set1.IntersectWith(set2));
            Console.WriteLine(set2.IntersectWith(set1));

            Console.WriteLine(set1.UnionWith(set2));
            Console.WriteLine(set2.UnionWith(set1));

            set1.Remove("Pesho");
            set1.Remove("Niki");
            Console.WriteLine(set1);

            Console.WriteLine(set1.Find("Doncho"));
            Console.WriteLine(set1.Find("Niki"));

            Console.WriteLine("Elements: {0}", set1.Count);
        }
    }
}