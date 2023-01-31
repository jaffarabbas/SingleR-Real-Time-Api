using KanbanApiUsingSingleR.Dtos;
using KanbanApiUsingSingleR.Models;
using Microsoft.AspNetCore.SignalR;
namespace KanbanApiUsingSingleR.HubService
{
    public class TodoHub : Hub
    {
        private readonly DbTodoContext _context;
        public TodoHub(DbTodoContext context) { 
            _context = context;
        }

        public async Task<List<Todo>> Get()
        {
            return _context.Todos.ToList();
        }
        
            public async Task<Todo> AddTodoHere(Todo todo)
             {
            // Save the todo to the database
            // ...
            var result = new Todo()
            {
                Name = todo.Name,
                Description = todo.Description,
            };
            Console.WriteLine("**************************************************************");
            _context.Todos.Add(result);
            var data = await _context.SaveChangesAsync();
            return data != null ? todo : null;
            // Notify all clients about the new todo
        }
    }
}
