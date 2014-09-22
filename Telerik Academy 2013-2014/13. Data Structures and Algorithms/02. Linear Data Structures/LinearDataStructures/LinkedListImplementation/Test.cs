/*
 * 11. Implement the data structure linked list. Define a class ListItem<T> that has two fields: 
 * value (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> 
 * with a single field FirstElement (of type ListItem<T>).
*/
namespace LinkedListImplementation
{
    using System;

    public class Test
    {
        public static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(3);
            list.AddLast(12);
            list.AddFirst(9);
            list.AddLast(-3);
            list.AddFirst(1223);
            list.AddLast(11);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            list.Remove(12);
            
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}