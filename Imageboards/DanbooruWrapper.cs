using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Imageboards
{
    /// <summary>
    /// Gets data from Danbooru imageboard.
    /// </summary>
    public class DanbooruWrapper
    {
        /// <summary>
        /// Imageboard URL.
        /// </summary>
        public static string Url { get { return "http://danbooru.donmai.us"; } }

        private string apiUrl = Url + "/posts.json";

        /// <summary>
        /// Gets 20 posts by a given tag string.
        /// </summary>
        /// <param name="tags">Tags to search posts for.</param>
        /// <returns>List of Post objects.</returns>
        public List<Post> GetPosts(string tags)
        {
            string apiPath = apiUrl + "?tags=" + tags;
            string jsonResult = GenerateRequest(apiPath);

            List<Post> result = String.IsNullOrEmpty(jsonResult)
                ? new List<Post>()
                : JsonConvert.DeserializeObject<List<Post>>(jsonResult);

            return result;
        }

        private string GenerateRequest(string apiPath)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiPath).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}