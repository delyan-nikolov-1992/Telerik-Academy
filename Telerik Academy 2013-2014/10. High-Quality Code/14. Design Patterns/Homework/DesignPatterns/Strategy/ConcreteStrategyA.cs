namespace Strategy
{
    using System;

    public class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Called ConcreteStrategyA.Execute()");
        }
    }
}