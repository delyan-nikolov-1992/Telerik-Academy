namespace Strategy
{
    public class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void UpdateContext(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Execute()
        {
            this.strategy.Execute();
        }
    }
}