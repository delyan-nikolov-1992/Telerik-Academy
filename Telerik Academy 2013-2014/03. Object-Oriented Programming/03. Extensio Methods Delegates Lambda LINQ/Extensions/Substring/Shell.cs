// Task 01

namespace Substring
{
    using System;
    using System.Text;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                StringBuilder input = new StringBuilder();
                input.Append("I want the substring \"Hello\"!");
                StringBuilder output = input.Substring(22, 5);

                Console.WriteLine(input.ToString());
                Console.WriteLine(output.ToString());
            }
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}