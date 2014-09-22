namespace ParseXMLToJSON
{
    using System.IO;
    using System.Xml.Linq;

    using Newtonsoft.Json;

    public class ParseXMLToJSON
    {
        public static void Main()
        {
            var doc = XDocument.Load("../../../Telerik Academy Forums - Recent questions and answers/qa.rss");
            string json = JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("../../../Telerik Academy Forums - Recent questions and answers/qa.json", json);
        }
    }
}