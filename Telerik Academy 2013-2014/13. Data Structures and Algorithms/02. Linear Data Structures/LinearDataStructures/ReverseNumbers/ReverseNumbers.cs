/*
 * 02. Write a program that reads N integers from the console and reverses 
 * them using a stack. Use the Stack<int> class.
*/
namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    public class ReverseNumbers
    {
        public static void Main()
        {
            try
            {
                Stack<int> numbers = ReadInput();

                Print(numbers);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The input number should be in the range [{0}, {1}]", int.MinValue, int.MaxValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("The input should be a valid integer!");
            }
        }

        private static Stack<int> ReadInput()
        {
            Console.Write("The number of integers = ");
            int size = int.Parse(Console.ReadLine());

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("The number of integers should be a positive number!");
            }

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < size; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                numbers.Push(currentNumber);
            }

            return numbers;
        }

        private static void Print(Stack<int> numbers)
        {
            Console.WriteLine("The reversed numbers:");

            while (numbers.Count > 0)
            {
                int currentNumber = numbers.Pop();
                Console.WriteLine(currentNumber);
            }
        }
    }
}