namespace Infestation
{
    public class WeaponrySkill : ISupplement
    {
        public WeaponrySkill()
        {

        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {

        }
    }
}