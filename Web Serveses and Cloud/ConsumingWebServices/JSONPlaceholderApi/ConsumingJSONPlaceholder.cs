namespace JSONPlaceholderApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class ConsumingJSONPlaceholder
    {
        private HttpClient httpClient;

        public ConsumingJSONPlaceholder()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
        }

        public void PrintLastTenTodos()
        {
            var resources = "todos";
            var response = this.httpClient.GetAsync(resources).Result;
            var todos = response.Content.ReadAsStringAsync().Result;
            var todosCollection = JsonConvert.DeserializeObject<IEnumerable<Todos>>(todos);

            todosCollection
                .Take(10)
                .ToList()
                .ForEach(a => Console.WriteLine("{0} - {1}", a.Completed ? "DONE: " : "TODO: ", a.Title));
        }

        public void UpdateTodosById(int id)
        {
            var resources = "todos/" + id;
            var response = this.httpClient.GetAsync(resources).Result;
            var todo = response.Content.ReadAsStringAsync().Result;
            var todoForUpdate = JsonConvert.DeserializeObject<Todos>(todo);
            todoForUpdate.Completed = !todoForUpdate.Completed;
            
            HttpContent todoContent = new StringContent(JsonConvert.SerializeObject(todoForUpdate));
            todoContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var result = this.httpClient.PutAsync(resources, todoContent).Result;
            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }

        public async void AddTodo(Todos todo)
        {
            var resource = "todos";
            HttpContent todoContent = new StringContent(JsonConvert.SerializeObject(todo));
            todoContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await this.httpClient.PostAsync(resource, todoContent);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
