namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;

    public class Table : Furniture, IFurniture, ITable
    {
        private decimal lenght;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal lenght, decimal width)
            : base(model, material, price, height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Area = lenght * width;
        }

        public decimal Length
        {
            get
            {
                return this.lenght;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The length of the table cannot be less or equal to 0.00 m!");
                }

                this.lenght = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width of the table cannot be less or equal to 0.00 m!");
                }

                this.width = value;
            }
        }

        public decimal Area { get; private set; }

        public override string ToString()
        {
            string format = "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}";

            return string.Format(format, this.GetType().Name, this.Model, this.Material, this.Price,
                this.Height, this.Length, this.Width, this.Area);
        }
    }
}