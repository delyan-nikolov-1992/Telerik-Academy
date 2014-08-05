using System;

class SortsStrings
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the array: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                string[] words = new string[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    words[i] = Console.ReadLine();
                }

                SortElements(words);

                foreach (string current in words)
                {
                    Console.WriteLine(current);
                }
            }
            else
            {
                Console.WriteLine("The size of the array must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void SortElements(string[] words)
    {
        int[] stringsLenghts = new int[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            stringsLenghts[i] = words[i].Length;
        }

        Array.Sort(stringsLenghts, words);
    }
}