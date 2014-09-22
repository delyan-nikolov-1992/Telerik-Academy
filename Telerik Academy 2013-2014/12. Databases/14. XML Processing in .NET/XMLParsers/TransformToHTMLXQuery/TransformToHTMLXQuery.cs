namespace TransformToHTMLXQuery
{
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    public class TransformToHTMLXQuery
    {
        public static void Main(string[] args)
        {
            XPathDocument myXPathDoc = new XPathDocument("../../../catalog.xml");
            XslCompiledTransform myXslTrans = new XslCompiledTransform();

            myXslTrans.Load("../../catalog.xslt");

            XmlTextWriter myWriter = new XmlTextWriter("../../catalog.html", Encoding.Unicode);

            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
    }
}