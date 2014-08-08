namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the company cannot be null or empty!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("The name of the company cannot be with less than 5 symbols!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                bool isNumber = value.All(char.IsDigit);

                if (!isNumber)
                {
                    throw new ArgumentException("The registration number of the company must contain only digits!");
                }

                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("The registration number of the company must be exactly 10 symbols!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("The furniture to be added cannot be null!");
            }

            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("The furniture to be removed cannot be null!");
            }

            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.furnitures)
            {
                if (furniture.Model.Equals(model, StringComparison.InvariantCultureIgnoreCase))
                {
                    return furniture;
                }
            }

            return null;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();

            string format = "{0} - {1} - {2} {3}";
            string furnitureCount = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
            string singularOrPlural = this.Furnitures.Count != 1 ? "furnitures" : "furniture";

            result.Append(string.Format(format, this.Name, this.RegistrationNumber, furnitureCount, singularOrPlural));

            var sortedFurnitures = this.furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);

            if (sortedFurnitures.Count() != 0)
            {
                result.AppendLine();

                for (int i = 0; i < sortedFurnitures.Count(); i++)
                {
                    result.Append(sortedFurnitures.ElementAt(i));

                    if (i != sortedFurnitures.Count() - 1)
                    {
                        result.AppendLine();
                    }
                }
            }

            return result.ToString();
        }
    }
}