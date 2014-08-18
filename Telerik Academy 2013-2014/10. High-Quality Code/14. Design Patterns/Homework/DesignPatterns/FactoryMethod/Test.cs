namespace FactoryMethod
{
    using System;

    public class Test
    {
        public static void Main()
        {
            // an array of creators
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // iterates over creators and creates products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }
        }
    }
}