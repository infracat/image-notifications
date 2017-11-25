using Newtonsoft.Json;

namespace ImageNotifications
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("preview_file_url")]
        public string PreviewUrl { get; set; }
    }
}