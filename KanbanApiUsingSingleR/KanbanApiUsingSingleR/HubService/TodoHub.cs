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
        public async Task AddTodo(TodoDtos todo)
        {
            // Save the todo to the database
            // ...
            if(todo != null) {
                var result = new Todo() 
                {
                    Name = todo.Name,
                    Description= todo.Description,
                };
                await _context.SaveChangesAsync();
            }
            // Notify all clients about the new todo
            await Clients.All.SendAsync("TodoAdded", todo);
        }
    }
}
