/*
 * 09. We are given the following sequence:
 * 
 * S1 = N;
 * S2 = S1 + 1;
 * S3 = 2*S1 + 1;
 * S4 = S1 + 2;
 * S5 = S2 + 1;
 * S6 = 2*S2 + 1;
 * S7 = S2 + 2;
 * ...
 * 
 * Using the Queue<T> class write a program to print its first 50 members for given N.
 * 
 * Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
*/
namespace PrintMembersOfSequence
{
    using System;
    using System.Collections.Generic;

    public class PrintMembersOfSequence
    {
        private const int MaxMembers = 50;

        public static void Main()
        {
            try
            {
                Console.Write("The start number of the sequence = ");
                int startNumber = int.Parse(Console.ReadLine());

                Queue<int> queue = CreateQueue(startNumber);

                Print(queue);
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

        private static Queue<int> CreateQueue(int startNumber)
        {
            Queue<int> resultQueue = new Queue<int>();
            Queue<int> searchedNumberQueue = new Queue<int>();
            int currentNumber = startNumber;

            for (int i = 0; i < MaxMembers; i++)
            {
                resultQueue.Enqueue(currentNumber);

                searchedNumberQueue.Enqueue(currentNumber + 1);
                searchedNumberQueue.Enqueue(2 * currentNumber + 1);
                searchedNumberQueue.Enqueue(currentNumber + 2);

                currentNumber = searchedNumberQueue.Dequeue();
            }

            return resultQueue;
        }

        private static void Print(Queue<int> queue)
        {
            byte counter = 1;
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();

                Console.WriteLine("{0}. Element = {1}", counter, number);
                counter++;
            }
        }
    }
}