/*
 * 10. We are given numbers N and M and the following operations:
 * 
 * N = N+1
 * N = N+2
 * N = N*2
 * 
 * Write a program that finds the shortest sequence of operations from 
 * the list above that starts from N and finishes in M. Hint: use a Queue.
 * 
 * Example: N = 5, M = 16
 * Sequence: 5 -> 7 -> 8 -> 16
*/
namespace ShortestSequence
{
    using System;
    using System.Collections.Generic;

    public class ShortestSequence
    {
        public static void Main()
        {
            try
            {
                Console.Write("Start number: ");
                int startNumber = int.Parse(Console.ReadLine());

                Console.Write("End number: ");
                int endNumber = int.Parse(Console.ReadLine());

                Queue<int> sequence = CalculateSequence(startNumber, endNumber);
                Print(sequence);
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

        private static Queue<int> CalculateSequence(int startNumber, int endNumber)
        {
            Queue<int> sequence = new Queue<int>();
            IList<int> numbersByMultiplication = new List<int>();
            int currentNumberByMultiplication = endNumber;

            sequence.Enqueue(startNumber);

            if (currentNumberByMultiplication % 2 != 0)
            {
                currentNumberByMultiplication -= 1;
            }

            while (true)
            {
                if (currentNumberByMultiplication / 2 >= startNumber)
                {
                    if (currentNumberByMultiplication == endNumber - 1)
                    {
                        numbersByMultiplication.Add(currentNumberByMultiplication);
                    }

                    if (currentNumberByMultiplication % 2 != 0)
                    {
                        currentNumberByMultiplication -= 1;
                        numbersByMultiplication.Add(currentNumberByMultiplication);
                    }

                    currentNumberByMultiplication /= 2;

                    if (currentNumberByMultiplication != startNumber)
                    {
                        numbersByMultiplication.Add(currentNumberByMultiplication);
                    }
                }
                else
                {
                    break;
                }
            }

            int currentNumber = startNumber;

            while (true)
            {
                if (currentNumber + 2 < currentNumberByMultiplication)
                {
                    currentNumber += 2;
                    sequence.Enqueue(currentNumber);
                    continue;
                }
                else if (currentNumber + 2 != currentNumberByMultiplication)
                {
                    if (currentNumber + 1 < currentNumberByMultiplication)
                    {
                        sequence.Enqueue(currentNumber);
                    }
                }

                break;
            }

            for (int i = numbersByMultiplication.Count - 1; i >= 0; i--)
            {
                sequence.Enqueue(numbersByMultiplication[i]);
            }

            sequence.Enqueue(endNumber);

            return sequence;
        }

        private static void Print(Queue<int> sequence)
        {
            while (sequence.Count > 1)
            {
                int currentNumber = sequence.Dequeue();
                Console.Write(currentNumber + ", ");
            }

            int lastNumber = sequence.Dequeue();
            Console.WriteLine(lastNumber);
        }
    }
}