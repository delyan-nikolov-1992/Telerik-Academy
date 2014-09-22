namespace ParseJSONToPOCO
{
    using Newtonsoft.Json;

    [JsonObject("guid")]
    public class Guid
    {
        [JsonProperty("@isPermaLink")]
        public bool IsPermaLink { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}