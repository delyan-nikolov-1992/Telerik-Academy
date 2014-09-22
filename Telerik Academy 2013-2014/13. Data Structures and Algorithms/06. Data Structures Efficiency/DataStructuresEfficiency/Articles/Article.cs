namespace Articles
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(string barcode, string vendor, string title, double price)
        {
            this.BarCode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string BarCode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}