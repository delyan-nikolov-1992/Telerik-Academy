// Task 17

namespace MaximumLength
{
    using System;
    using System.Linq;

    public class Shell
    {
        public static void Main()
        {
            string[] words = new string[] { "d", "yes", "no", "longer" };
            var longestWord = words.OrderByDescending(w => w.Length).First();
            Console.WriteLine("The string with maximum length is: {0}", longestWord);
        }
    }
}