using System;
using Newtonsoft.Json;

namespace FirstAndroidApp.Dto
{
    public class CardDetailsDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imageHref")]
        public string ImageUrl { get; set; }
    }
}
