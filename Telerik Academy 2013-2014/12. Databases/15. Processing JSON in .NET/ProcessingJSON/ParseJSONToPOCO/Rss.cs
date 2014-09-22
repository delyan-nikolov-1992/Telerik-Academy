namespace ParseJSONToPOCO
{
    using Newtonsoft.Json;

    [JsonObject("rss")]
    public class Rss
    {
        [JsonProperty("@version")]
        public double Version { get; set; }

        [JsonProperty("channel")]
        public Channel Channel { get; set; }
    }
}