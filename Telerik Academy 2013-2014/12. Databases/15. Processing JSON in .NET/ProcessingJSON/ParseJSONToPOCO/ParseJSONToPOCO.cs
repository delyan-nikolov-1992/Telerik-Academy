namespace ParseJSONToPOCO
{
    using System.IO;

    using Newtonsoft.Json;

    public class ParseJSONToPOCO
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../Telerik Academy Forums - Recent questions and answers/qa.json"))
            {
                string json = reader.ReadToEnd();

                var poco = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }
    }
}