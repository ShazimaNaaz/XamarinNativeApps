using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FirstAndroidApp
{
    public class CardDetailsModel
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("rows")]
        public List<RowsList> rows { get; set; }
    }

    public class RowsList
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("imageHref")]
        public string imageHref { get; set; }
    }
}
