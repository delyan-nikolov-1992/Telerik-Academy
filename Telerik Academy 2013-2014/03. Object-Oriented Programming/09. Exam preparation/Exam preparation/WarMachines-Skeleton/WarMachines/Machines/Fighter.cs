namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter, IMachine
    {
        private const int INITIAL_HEALTH_POINTS = 200;

        public Fighter(string name, double attackPoints, double defencePoints, bool stealthMode)
            : base(name, INITIAL_HEALTH_POINTS, attackPoints, defencePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            string stealthModeAsString = this.StealthMode ? ON : OFF;

            result.AppendLine(base.ToString());
            result.Append(string.Format(" *Stealth: {0}", stealthModeAsString));

            return result.ToString();
        }
    }
}
