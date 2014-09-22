/*
 * 12. Implement the ADT stack as auto-resizable array. Resize the capacity on demand 
 * (when no space is available to add / insert a new element).
*/
namespace StackImplementation
{
    using System;

    public class Test
    {
        public static void Main()
        {
            try
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(12);
                stack.Push(11);
                stack.Push(-4);
                stack.Push(0);

                Console.WriteLine("Peeking First: " + stack.Peek());
                Console.WriteLine("Popping: " + stack.Pop());
                Console.WriteLine("Popping: " + stack.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}