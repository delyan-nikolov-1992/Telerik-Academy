namespace Decorator
{
    using System;

    public class Test
    {
        public static void Display(string operation, IComponent component)
        {
            Console.WriteLine(operation + component.Operation());
        }

        public static void Main()
        {
            Console.WriteLine("Decorator Pattern\n");

            IComponent component = new Component();
            Display("1. Basic component: ", component);
            Display("2. A-decorated : ", new DecoratorA(component));

            Console.ReadLine();
            Display("3. B-decorated : ", new DecoratorB(component));

            Console.ReadLine();
            Display("4. B-A-decorated : ", new DecoratorB(new DecoratorA(component)));

            // explicit DecoratorB
            Console.ReadLine();
            DecoratorB b = new DecoratorB(new Component());
            Display("5. A-B-decorated : ", new DecoratorA(b));

            // invoking its added state and added behavior
            Console.WriteLine("\t\t\t" + b.AddedState + b.AddedBehavior());
        }
    }
}