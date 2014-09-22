namespace ParseJSONToPOCO
{
    using Newtonsoft.Json;

    [JsonObject("?xml")]
    public class Xml
    {
        [JsonProperty("@version")]
        public double Version { get; set; }

        [JsonProperty("@encoding")]
        public string Encoding { get; set; }
    }
}