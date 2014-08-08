namespace Infestation
{
    public class InfestationSpores : ISupplement
    {
        public InfestationSpores()
        {
            this.AggressionEffect = 20;
            this.PowerEffect = -1;
        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.AggressionEffect = 0;
                this.PowerEffect = 0;
            }
        }
    }
}