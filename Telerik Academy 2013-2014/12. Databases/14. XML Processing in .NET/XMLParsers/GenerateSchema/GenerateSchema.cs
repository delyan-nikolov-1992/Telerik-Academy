namespace GenerateSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class GenerateSchema
    {
        public static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "../../catalog.xsd");

            XDocument invalidDocument = XDocument.Load("../../catalog-invalid.xml");
            bool hasErrors = false;

            invalidDocument.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                hasErrors = true;
            });

            Console.WriteLine("Second document is {0} valid", hasErrors ? "not" : "");
        }
    }
}