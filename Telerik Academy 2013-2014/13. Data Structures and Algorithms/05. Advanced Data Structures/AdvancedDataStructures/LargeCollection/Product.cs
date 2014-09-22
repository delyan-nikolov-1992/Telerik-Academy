namespace LargeCollection
{
    using System;

    public class Product : IComparable
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Product otherProduct = obj as Product;

            if (otherProduct != null)
            {
                return this.Price.CompareTo(otherProduct.Price);
            }
            else
            {
                throw new ArgumentException("Object is not a Product");
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}; Price: {1}", this.Name, this.Price);
        }
    }
}