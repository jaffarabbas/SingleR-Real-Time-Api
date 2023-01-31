using KanbanApiUsingSingleR.HubService;
using KanbanApiUsingSingleR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace KanbanApiUsingSingleR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IHubContext<TodoHub> _todoHub;
        public TodoController(IHubContext<TodoHub> todoHub) 
        { 
            _todoHub= todoHub;
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody]Todo todo)
        {
            try
            {
                await _todoHub.Clients.All.SendAsync("AddTodoHere", todo);

                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
