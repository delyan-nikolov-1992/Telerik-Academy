namespace ImplementingPriorityQueue
{
    using System;

    public class TestPriorityQueue
    {
        public static void Main()
        {
            Console.WriteLine("Creating priority queue of int items\n");
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            int firstNumber = 10;
            int secondNumber = 20;
            int thirdNumber = 30;
            int fourthNumber = 40;
            int fifthNumber = 50;
            int sixthNumber = 60;

            Console.WriteLine("Adding " + fifthNumber.ToString() + " to priority queue");
            priorityQueue.Enqueue(fifthNumber);
            Console.WriteLine("Adding " + thirdNumber.ToString() + " to priority queue");
            priorityQueue.Enqueue(thirdNumber);
            Console.WriteLine("Adding " + sixthNumber.ToString() + " to priority queue");
            priorityQueue.Enqueue(sixthNumber);
            Console.WriteLine("Adding " + fourthNumber.ToString() + " to priority queue");
            priorityQueue.Enqueue(fourthNumber);
            Console.WriteLine("Adding " + firstNumber.ToString() + " to priority queue");
            priorityQueue.Enqueue(firstNumber);
            Console.WriteLine("Adding " + secondNumber.ToString() + " to priority queue");
            priorityQueue.Enqueue(secondNumber);

            Console.WriteLine("\nPriory queue is: ");
            Console.WriteLine(priorityQueue.ToString());

            Console.WriteLine("Removing an int from priority queue");
            int lastNumber = priorityQueue.Dequeue();
            Console.WriteLine("Removed int is " + lastNumber.ToString());
            Console.WriteLine("\nPriory queue is now: ");
            Console.WriteLine(priorityQueue.ToString());

            Console.WriteLine("Removing a second int from queue");
            lastNumber = priorityQueue.Dequeue();
            Console.WriteLine("\nPriory queue is now: ");
            Console.WriteLine(priorityQueue.ToString());
        }
    }
}