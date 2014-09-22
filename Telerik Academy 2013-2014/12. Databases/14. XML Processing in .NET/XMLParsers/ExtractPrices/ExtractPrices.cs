namespace ExtractPrices
{
    using System;
    using System.Xml.XPath;

    public class ExtractPrices
    {
        public static void Main(string[] args)
        {
            XPathDocument docNav = new XPathDocument("../../../catalog.xml");
            XPathNavigator nav = docNav.CreateNavigator();
            string strExpression = "/catalog/album[year>2005]/price";

            var prices = nav.Select(strExpression);

            while (prices.MoveNext())
            {
                Console.WriteLine(prices.Current.Value);
            }
        }
    }
}