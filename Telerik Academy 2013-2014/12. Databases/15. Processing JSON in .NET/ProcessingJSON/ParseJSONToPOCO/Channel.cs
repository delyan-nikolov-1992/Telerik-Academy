namespace ParseJSONToPOCO
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [JsonObject("channel")]
    public class Channel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("item")]
        public IList<Item> Item { get; set; }
    }
}