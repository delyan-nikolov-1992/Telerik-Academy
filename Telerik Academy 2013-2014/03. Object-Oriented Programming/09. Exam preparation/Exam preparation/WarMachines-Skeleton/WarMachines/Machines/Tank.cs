namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Tank : Machine, ITank, IMachine
    {
        private const int INITIAL_HEALTH_POINTS = 100;
        private const int ATTACK_POINTS_MODIFIER = 40;
        private const int DEFENCE_POINTS_MODIFIER = 30;

        public Tank(string name, double attackPoints, double defencePoints)
            : base(name, INITIAL_HEALTH_POINTS, attackPoints, defencePoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints += ATTACK_POINTS_MODIFIER;
                this.DefensePoints -= DEFENCE_POINTS_MODIFIER;
            }
            else
            {
                this.AttackPoints -= ATTACK_POINTS_MODIFIER;
                this.DefensePoints += DEFENCE_POINTS_MODIFIER;
            }

            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            string defenceModeAsString = this.DefenseMode ? ON : OFF;

            result.AppendLine(base.ToString());
            result.Append(string.Format(" *Defense: {0}", defenceModeAsString));

            return result.ToString();
        }
    }
}
