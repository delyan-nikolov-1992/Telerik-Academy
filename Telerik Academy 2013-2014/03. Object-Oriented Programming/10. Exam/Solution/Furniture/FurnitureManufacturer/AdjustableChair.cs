namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : Chair, IFurniture, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {

        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public override string ToString()
        {
            string format = "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}";

            return string.Format(format, this.GetType().Name, this.Model, this.Material, this.Price,
                this.Height, this.NumberOfLegs);
        }
    }
}