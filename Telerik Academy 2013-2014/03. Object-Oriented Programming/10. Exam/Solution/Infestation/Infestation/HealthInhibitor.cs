namespace Infestation
{
    public class HealthInhibitor : Inhibitor, ISupplement
    {
        private const int InitialHealthEffect = 3;

        public HealthInhibitor()
            : base()
        {
            this.HealthEffect = HealthInhibitor.InitialHealthEffect;
        }
    }
}