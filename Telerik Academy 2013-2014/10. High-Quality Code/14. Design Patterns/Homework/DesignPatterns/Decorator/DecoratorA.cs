namespace Decorator
{
    public class DecoratorA : IComponent
    {
        private IComponent component;

        public DecoratorA(IComponent component)
        {
            this.component = component;
        }

        public string Operation()
        {
            string operation = this.component.Operation();
            operation += "and listening to Classic FM ";

            return operation;
        }
    }
}