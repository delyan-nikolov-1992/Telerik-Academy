namespace FarmVille
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                Dog[] dogs = new Dog[]
                {
                    new Dog(4, "Doggy", true),
                    new Dog(7, "Sharo", false),
                    new Dog(2, "Lucky", false)
                };

                Frog[] frogs = new Frog[]
                {
                    new Frog(25, "Froggy", true),
                    new Frog(19, "Dundi", true),
                    new Frog(3, "Bamby", false)
                };

                Cat[] cats = new Cat[]
                {
                    new Cat(4, "Lora", true),
                    new Tomcat(5, "Garry"),
                    new Kitten(12, "Kitty")
                };

                Console.WriteLine(dogs[2].ToString());
                Console.WriteLine();
                Console.WriteLine(cats[1].ToString());
                Console.WriteLine();
                Console.WriteLine(frogs[2].Sound());
                Console.WriteLine(cats[2].Sound());
                Console.WriteLine();
                Console.WriteLine("Average age of dogs " + Animal.AverageAge(dogs));
                Console.WriteLine("Average age of frogs " + Animal.AverageAge(frogs));
                Console.WriteLine("Average age of cats " + Animal.AverageAge(cats));
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}