using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using TodoWebAPI.Models.Todo;

namespace TodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController
    {
        ITodoRepository TodoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            TodoRepository = todoRepository;
        }

        [HttpGet(Name = "GetAllItems")] 
        public IEnumerable<TodoItem> Get() => TodoRepository.Get();

        [HttpGet("{id}", Name = "GetTodoItem")]
        public IActionResult Get(int id) 
        {
            var item = TodoRepository.Get(id);
            if (item == null)
                return new NotFoundResult();
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
                return new BadRequestResult();
            TodoRepository.Create(item);
            return new CreatedAtRouteResult("GetTodoItem", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
                return new BadRequestResult();
            if (TodoRepository.Get(id) == null)
                return new BadRequestResult();
            TodoRepository.Update(item);
            return new RedirectToRouteResult("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = TodoRepository.Delete(id);
            if (item == null)
                return new BadRequestResult();
            return new ObjectResult(item);
        }
    }
}
