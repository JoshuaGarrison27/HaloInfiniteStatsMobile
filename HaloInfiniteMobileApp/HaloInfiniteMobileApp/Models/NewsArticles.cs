using Newtonsoft.Json;
using System.Collections.Generic;

namespace HaloInfiniteMobileApp.Models
{
    public class NewsArticles
    {
        [JsonProperty("data")]
        public IEnumerable<Article> Data { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("additional")]
        public AdditionalArticleProperties Additional { get; set; }
    }

    public class Article
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }

    public class AdditionalArticleProperties
    {
        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class NewsArticlesRequest
    {
        [JsonProperty("language")]
        public string Language = "en-US";
    }
}
