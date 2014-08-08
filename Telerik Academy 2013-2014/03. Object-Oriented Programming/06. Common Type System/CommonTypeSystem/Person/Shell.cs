namespace Person
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                Person firstPerson = new Person("Pesho", 12);
                Person secondPerson = new Person("Stefan");

                Console.WriteLine("First person:");
                Console.WriteLine(firstPerson);
                Console.WriteLine("Second person:");
                Console.WriteLine(secondPerson);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}