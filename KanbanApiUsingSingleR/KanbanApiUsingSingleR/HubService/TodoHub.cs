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
        public async Task AddTodoHere(TodoDtos todo)
        {
            // Save the todo to the database
            // ...
            var result = new Todo()
            {
                Name = todo.Name,
                Description = todo.Description,
            };
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("AddTodoHere", result);
            // Notify all clients about the new todo
        }
    }
}
