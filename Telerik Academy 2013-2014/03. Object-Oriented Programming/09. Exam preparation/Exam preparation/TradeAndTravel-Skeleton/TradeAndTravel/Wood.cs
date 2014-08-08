namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, GeneralWoodValue, ItemType.Weapon, location)
        {

        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction.Equals("drop") && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}