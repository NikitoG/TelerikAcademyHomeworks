namespace JSONPlaceholderApi
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var consumingApi = new ConsumingJSONPlaceholder();

            Console.WriteLine("Get: ");
            consumingApi.PrintLastTenTodos();

            Console.WriteLine("Put: ");
            consumingApi.UpdateTodosById(200);

            Console.WriteLine("Post: ");
            var todo = new Todos() { UserId = 5, Title = "Must do it.", Completed = false };
            consumingApi.AddTodo(todo);
            Console.ReadLine();
        }
    }
}
