namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model of the furniture cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The model of the furniture cannot be with less than 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The material of the furniture cannot be null or empty!");
                }

                if (value.Equals("wooden", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.material = MaterialType.Wooden.ToString();
                }
                else if (value.Equals("leather", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.material = MaterialType.Leather.ToString();
                }
                else if (value.Equals("plastic", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.material = MaterialType.Plastic.ToString();
                }
                else
                {
                    throw new ArgumentException("There is no such material for the furniture!");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price of the furniture cannot be less or equal to $ 0.00!");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height of the furniture cannot be less or equal to 0.00 m!");
                }

                this.height = value;
            }
        }
    }
}