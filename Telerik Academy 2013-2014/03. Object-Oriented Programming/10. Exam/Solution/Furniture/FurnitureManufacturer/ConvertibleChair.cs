namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IFurniture, IChair, IConvertibleChair
    {
        private static decimal InitialHeight;

        private bool isConverted;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            InitialHeight = height;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }

            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (!this.isConverted)
            {
                this.Height = 0.10m;
            }
            else
            {
                this.Height = InitialHeight;
            }

            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            string format = "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}";
            string converted = this.IsConverted ? "Converted" : "Normal";

            return string.Format(format, this.GetType().Name, this.Model, this.Material, this.Price,
                this.Height, this.NumberOfLegs, converted);
        }
    }
}