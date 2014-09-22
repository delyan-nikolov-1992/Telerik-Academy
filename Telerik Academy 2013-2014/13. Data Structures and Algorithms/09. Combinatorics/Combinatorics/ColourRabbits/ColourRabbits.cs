// 02. Task from Telerik Algo Academy @ October 2012
namespace ColourRabbits
{
    using System;
    using System.Collections.Generic;

    public class ColourRabbits
    {
        public static void Main()
        {
            int askedRabbits = int.Parse(Console.ReadLine());
            int result = 0;
            IDictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < askedRabbits; i++)
            {
                int answer = int.Parse(Console.ReadLine());
                int count = 1;

                if (dictionary.ContainsKey(answer))
                {
                    count = dictionary[answer] + 1;
                }

                dictionary[answer] = count;
            }

            foreach (var pair in dictionary)
            {
                int currentRabbits = pair.Key + 1;
                int numberOfCurrentRabbits = currentRabbits;

                if (pair.Value > numberOfCurrentRabbits)
                {
                    for (int i = numberOfCurrentRabbits + 1; i <= pair.Value; i++)
                    {
                        if (pair.Key == 0)
                        {
                            numberOfCurrentRabbits++;
                        }
                        else if (i % currentRabbits == 1)
                        {
                            numberOfCurrentRabbits += currentRabbits;
                        }
                    }
                }

                result += numberOfCurrentRabbits;
            }

            Console.WriteLine(result);
        }
    }
}