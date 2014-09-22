namespace PrintTitles
{
    using System;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json.Linq;

    public class PrintTitles
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../Telerik Academy Forums - Recent questions and answers/qa.json"))
            {
                string json = reader.ReadToEnd();
                var jsonObj = JObject.Parse(json);

                var titles = jsonObj["rss"]["channel"]["item"].Select(item => item["title"]);

                foreach (var currentTitle in titles)
                {
                    Console.WriteLine(currentTitle);
                }
            }
        }
    }
}