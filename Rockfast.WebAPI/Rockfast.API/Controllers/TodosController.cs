using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rockfast.ApiDatabase.DomainModels;
using Rockfast.ServiceInterfaces;
using Rockfast.ViewModels;

namespace Rockfast.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private ILogger<TodosController> _logger;
        public TodosController(ITodoService todoService, ILogger<TodosController> logger)
        {
            this._todoService = todoService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAll() => await _todoService.GetAllTodo();

        [HttpGet("{id}")]
        public async Task<Todo> Get(int id)
        {
            var todo = await _todoService.GetTodo(id);

            return todo;
        }

        [HttpPost]
        public async Task<Todo> Post(Todo todo)
        {
            await _todoService.CreateTodo(todo);
            return todo;
        }

        [HttpPut("{id}")]
        public async Task<Todo> Put(int id, Todo todo)
        {
            await _todoService.UpdateTodo(id, todo);
            return todo;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _todoService.DeleteTodo(id);
        }
    }
}
