namespace ExtractPricesLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractPricesLINQ
    {
        public static void Main()
        {
            var document = XDocument.Load("../../../catalog.xml");

            var prices = document.Descendants("album")
                .Where(album => int.Parse(album.Descendants("year").FirstOrDefault().Value) > 2005)
                .Select(album => album.Descendants("price").FirstOrDefault().Value);

            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}