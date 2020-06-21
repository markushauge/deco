using Newtonsoft.Json;
using Deco.Demo.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Deco.Demo {
    public class TodoApi {
        private static readonly HttpClient Client = new HttpClient {
            Timeout = TimeSpan.FromSeconds(5)
        };

        private static readonly Random Random = new Random();

        private static async Task<T> Get<T>(string url) {
            await Task.Delay(Random.Next(0, 1000));
            return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url));
        }

        public static readonly Func<int, Task<TodoModel>> GetTodo = id =>
            Get<TodoModel>($"https://jsonplaceholder.typicode.com/todos/{id}");
    }
}
