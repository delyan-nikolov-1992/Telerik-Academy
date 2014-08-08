namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;

    public class Chair : Furniture, IFurniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of legs of the table cannot be less or equal to 0!");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            string format = "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}";

            return string.Format(format, this.GetType().Name, this.Model, this.Material, this.Price, 
                this.Height, this.NumberOfLegs);
        }
    }
}