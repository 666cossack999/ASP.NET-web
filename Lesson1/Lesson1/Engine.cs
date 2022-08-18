using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson1
{
    public class Engine
    {

        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Получаем JSON пост по id
        /// </summary>
        /// <param name="id">id поста</param>
        /// <returns>JSON</returns>
        public static async Task<Post> GetPostById(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($@"https://jsonplaceholder.typicode.com/posts/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Post post = JsonConvert.DeserializeObject<Post>(responseBody);
                return post;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
