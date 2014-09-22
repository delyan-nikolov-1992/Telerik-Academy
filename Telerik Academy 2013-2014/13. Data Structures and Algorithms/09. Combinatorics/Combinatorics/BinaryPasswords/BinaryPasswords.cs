// 01. Task from Telerik Algo Academy @ October 2012
namespace BinaryPasswords
{
    using System;

    public class BinaryPasswords
    {
        public static void Main()
        {
            string password = Console.ReadLine();
            long numberOfPasswords = 1;

            foreach (char symbol in password)
            {
                if (symbol == '*')
                {
                    numberOfPasswords *= 2;
                }
            }

            Console.WriteLine(numberOfPasswords);
        }
    }
}