using KanbanApiUsingSingleR.Dtos;
using KanbanApiUsingSingleR.Models;

namespace KanbanApiUsingSingleR.HubService
{
    public interface IHubService
    {
        Task<Todo> AddTodoHere(Todo todo);
    }
}
