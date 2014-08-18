namespace Strategy
{
    public class MainApp
    {
        public static void Main()
        {
            Context context;

            // three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.Execute();

            context.UpdateContext(new ConcreteStrategyB());
            context.Execute();

            context.UpdateContext(new ConcreteStrategyC());
            context.Execute();
        }
    }
}