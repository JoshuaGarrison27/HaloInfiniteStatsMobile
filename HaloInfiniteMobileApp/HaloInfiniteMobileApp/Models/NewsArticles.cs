using Newtonsoft.Json;
using System.Collections.Generic;

namespace HaloInfiniteMobileApp.Models
{
    public class NewsArticles
    {
        public List<Article> Data { get; set; }
        public int Count { get; set; }
        public AdditionalArticleProperties Additional { get; set; }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Message { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }

    public class AdditionalArticleProperties
    {
        public string Language { get; set; }
    }
}
