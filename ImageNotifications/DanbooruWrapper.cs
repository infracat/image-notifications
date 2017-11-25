using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ImageNotifications
{
    public class DanbooruWrapper
    {
        private string apiUrl = "http://danbooru.donmai.us/posts.json";

        public List<Post> GetPosts(string tags)
        {
            string apiPath = apiUrl += "?tags=" + tags;
            string jsonResult = GenerateRequest(apiPath);

            List<Post> result = JsonConvert.DeserializeObject<List<Post>>(jsonResult);
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
