namespace JasonProcessingInDotNet
{
    using Newtonsoft.Json;

    class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public URL Link { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }
    }
}
