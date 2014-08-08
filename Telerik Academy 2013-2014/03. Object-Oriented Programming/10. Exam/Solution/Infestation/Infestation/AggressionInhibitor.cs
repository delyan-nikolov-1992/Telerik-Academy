namespace Infestation
{
    public class AggressionInhibitor : Inhibitor, ISupplement
    {
        private const int InitialAggressionEffect = 3;

        public AggressionInhibitor()
            : base()
        {
            this.AggressionEffect = AggressionInhibitor.InitialAggressionEffect;
        }
    }
}