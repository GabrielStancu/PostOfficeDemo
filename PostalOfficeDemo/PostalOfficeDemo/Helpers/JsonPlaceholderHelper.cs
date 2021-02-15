using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostalOfficeDemo.Helpers
{
    public static class JsonPlaceholderHelper
    {
        const string BASE_URL = "https://jsonplaceholder.typicode.com/";
        const string POST_ENDPOINT = "posts";

        public static async Task<List<Post>> GetPostsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + POST_ENDPOINT);
                var posts = JsonConvert.DeserializeObject<List<Post>>(jsonString);

                return posts;
            }
        }
    }
}
