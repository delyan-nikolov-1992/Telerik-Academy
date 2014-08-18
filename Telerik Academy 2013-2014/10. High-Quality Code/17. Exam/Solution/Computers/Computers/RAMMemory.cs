namespace Computers
{
    public class RamMemory : IRamMemory
    {
        public RamMemory(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; private set; }

        public void SaveValue(int newValue)
        {
            this.Amount = newValue;
        }

        public int LoadValue()
        {
            return this.Amount;
        }
    }
}