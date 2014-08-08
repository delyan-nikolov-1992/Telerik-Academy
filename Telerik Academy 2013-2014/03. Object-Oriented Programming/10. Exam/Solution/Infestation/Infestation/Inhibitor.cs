namespace Infestation
{
    public abstract class Inhibitor : ISupplement
    {
        public Inhibitor()
        {

        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public void ReactTo(ISupplement otherSupplement)
        {

        }
    }
}