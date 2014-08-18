namespace Decorator
{
    public class DecoratorB : IComponent
    {
        public readonly string AddedState = "past the Coffee Shop ";

        private IComponent component;

        public DecoratorB(IComponent component)
        {
            this.component = component;
        }

        public string Operation()
        {
            string operation = this.component.Operation();
            operation += "to school ";

            return operation;
        }

        public string AddedBehavior()
        {
            return "and I bought a cappuccino ";
        }
    }
}