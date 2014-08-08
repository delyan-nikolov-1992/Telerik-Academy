namespace Infestation
{
    public class PowerInhibitor : Inhibitor, ISupplement
    {
        private const int InitialPowerEffect = 3;

        public PowerInhibitor()
            : base()
        {
            this.PowerEffect = PowerInhibitor.InitialPowerEffect;
        }
    }
}