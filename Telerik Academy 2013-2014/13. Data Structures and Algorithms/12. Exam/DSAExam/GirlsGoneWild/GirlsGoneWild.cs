namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    public class GirlsGoneWild
    {
        private static SortedSet<string> combinations = new SortedSet<string>();
        private static StringBuilder result = new StringBuilder();
        private static List<Clothes> allClothes = new List<Clothes>();
        private static Bag<char> charsOfClothes = new Bag<char>();
        private static int numberOfGirls;

        public static void Main()
        {
            int numberOfShirts = int.Parse(Console.ReadLine());
            var skirts = Console.ReadLine();
            numberOfGirls = int.Parse(Console.ReadLine());

            for (int j = 0; j < skirts.Length; j++)
            {
                charsOfClothes.Add(skirts[j]);
            }

            for (int i = 0; i < numberOfShirts; i++)
            {
                for (int j = 0; j < skirts.Length; j++)
                {
                    var clothes = new Clothes(i, skirts[j]);
                    allClothes.Add(new Clothes(i, skirts[j]));
                }
            }

            GenerateCombinationsNoRepetitions(0, 0);

            var forRemove = new List<string>();

            foreach (var item in combinations)
            {
                string first = Sep(item);
                string second = SepBackwards(item);
                string notToBeRemoved = first + "-" + second;
                string toBeRemoved = second + "-" + first;

                if (combinations.Contains(toBeRemoved) && !forRemove.Contains(notToBeRemoved))
                {
                    forRemove.Add(toBeRemoved);
                }
            }

            foreach (var item in forRemove)
            {
                combinations.Remove(item);
            }

            foreach (var item in combinations)
            {

                result.AppendLine(item);
            }

            Console.WriteLine(combinations.Count);
            Console.WriteLine(result.ToString().Trim());
        }

        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= numberOfGirls)
            {
                var currentElements = allClothes.Take(numberOfGirls).ToList();
                var currentCounter = charsOfClothes.NumberOfCopies(currentElements[0].Skirt);
                int counter = 0;

                for (int i = 1; i < currentElements.Count; i++)
                {
                    if (currentElements[0].Shirt == currentElements[i].Shirt)
                    {
                        return;
                    }

                    if (currentElements[0].Skirt == currentElements[i].Skirt)
                    {
                        counter++;
                    }

                    if (counter == currentCounter)
                    {
                        return;
                    }
                }

                var currentClothes = string.Join("-", currentElements);
                combinations.Add(currentClothes);
            }
            else
            {
                for (int i = start; i < allClothes.Count; i++)
                {
                    allClothes[index] = allClothes[i];
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        private static string Sep(string s)
        {
            int l = s.IndexOf("-");

            if (l > 0)
            {
                return s.Substring(0, l);
            }
            return "";

        }

        private static string SepBackwards(string s)
        {
            int l = s.IndexOf("-");

            if (l > 0)
            {
                return s.Substring(l + 1, s.Length - (l + 1));
            }
            return "";

        }
    }

    public struct Clothes
    {
        public Clothes(int shirt, char skirt)
            : this()
        {
            this.Shirt = shirt;
            this.Skirt = skirt;
        }

        public int Shirt { get; set; }

        public char Skirt { get; set; }

        public override string ToString()
        {
            return this.Shirt.ToString() + this.Skirt.ToString();
        }
    }
}