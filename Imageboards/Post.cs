using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Reflection;

namespace Imageboards
{
    /// <summary>
    /// Represents post on imageboard.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Post ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// URL of image preview (relatively to imageboard URL).
        /// </summary>
        [JsonProperty("preview_file_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Downloads post preview to application temp folder.
        /// </summary>
        /// <param name="imageboardUrl">URL of imageboard.</param>
        /// <returns>Local path to downloaded preview.</returns>
        public string DownloadPreview(string imageboardUrl)
        {
            var url = imageboardUrl + PreviewUrl;
            var tempDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Temp\\";
            var tempFilePath = tempDirectory + Id + Path.GetExtension(PreviewUrl);

            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            using (var client = new WebClient())
            {
                client.DownloadFile(url, tempFilePath);
            }

            return tempFilePath;
        }
    }
}