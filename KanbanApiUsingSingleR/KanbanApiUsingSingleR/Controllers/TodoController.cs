using KanbanApiUsingSingleR.Dtos;
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

        [HttpGet]
        public IActionResult Get()
        {
            var r = _todoHub.Clients.All.SendAsync("Get");
            return Ok(r);
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody]TodoDtos todo)
        {
            try
            {
                var result = _todoHub.Clients.All.SendAsync("AddTodoHere", todo);
                if(result != null)
                {
                    return Ok(todo);
                }
                return BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
