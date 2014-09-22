/*
 * 13. Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) 
 * to allow storing different data types in the queue.
*/
namespace QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main()
        {
            try
            {
                LinkedQueue<int> queue = new LinkedQueue<int>();
                queue.Enqueue(12);
                queue.Enqueue(11);
                queue.Enqueue(-4);
                queue.Enqueue(0);

                Console.WriteLine("Peeking First: " + queue.Peek());
                Console.WriteLine("Dequing: " + queue.Dequeue());
                Console.WriteLine("Dequing: " + queue.Dequeue());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}