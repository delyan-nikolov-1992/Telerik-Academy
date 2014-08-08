namespace Infestation
{
    public class Weapon : ISupplement
    {
        private const int InitialPowerEffect = 10;
        private const int InitialAggressionEffect = 3;

        public Weapon()
        {

        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.InitialPowerEffect;
                this.AggressionEffect = Weapon.InitialAggressionEffect;
            }
        }
    }
}