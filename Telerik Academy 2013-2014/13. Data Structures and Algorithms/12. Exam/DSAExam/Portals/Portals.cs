namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class GirlsGoneWild
    {
        private static SortedSet<string> combinations = new SortedSet<string>();
        private static StringBuilder result = new StringBuilder();
        private static HashSet<Clothes> allClothes = new HashSet<Clothes>();
        private static List<Clothes> newClothes = new List<Clothes>();
        private static int numberOfGirls;

        public static void Main()
        {
            int numberOfShirts = int.Parse(Console.ReadLine());
            var skirts = Console.ReadLine();
            numberOfGirls = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfShirts; i++)
            {
                for (int j = 0; j < skirts.Length; j++)
                {
                    var clothes = new Clothes(i, skirts[j]);
                    allClothes.Add(new Clothes(i, skirts[j]));
                }
            }

            newClothes = allClothes.ToList();

            GenerateCombinationsNoRepetitions(0, 0);

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

                for (int i = 1; i < currentElements.Count; i++)
                {
                    if (currentElements[0].Shirt == currentElements[i].Shirt)
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
                    newClothes[index] = newClothes[i];
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }
    }


    public class Clothes
    {
        public Clothes(int shirt, Char skirt)
        {
            this.Shirt = shirt;
            this.Skirt = skirt;
        }

        public int Shirt { get; set; }

        public Char Skirt { get; set; }

        //public override bool Equals(Object obj)
        //{
        //    Clothes clothesObj = obj as Clothes;

        //    if (clothesObj == null)
        //    {
        //        return false;
        //    }

        //    if (this.Shirt == clothesObj.Shirt && this.Skirt == clothesObj.Skirt)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return this.Shirt.GetHashCode() + this.Skirt.GetHashCode();
        //}

        public override string ToString()
        {
            return this.Shirt.ToString() + this.Skirt.ToString();
        }
    }
}