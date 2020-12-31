using Microsoft.AspNetCore.Mvc;
using PlannerAPI.Models;
using PlannerAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerAPI.Controllers
{
  [ApiController]
  [Route("api/todoitems")]
  public class TodoItemController : ControllerBase
  {
    private ITodoItemService _todoItemService;

    public TodoItemController(ITodoItemService todoItemService)
    {
      _todoItemService = todoItemService;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoItem>> GetTasks() => await _todoItemService.GetAllTasks();
    
    [HttpGet("current")]
    public async Task<IEnumerable<TodoItem>> GetCurrentTasks() => await _todoItemService.GetCurrentTasks();

    [HttpGet("overdue")]
    public async Task<IEnumerable<TodoItem>> GetOverdueTasks() => await _todoItemService.GetOverdueTasks();

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
      var task = await _todoItemService.GetTask(id);
      if (task != null)
        return Ok(task);
      else
        return BadRequest();
    }

    [HttpPost]
    public async Task CreateItem(TodoItem item) => await _todoItemService.CreateTask(item);

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, TodoItem item)
    {
      if (await _todoItemService.UpdateTask(id, item))
        return Ok();
      else
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
      if (await _todoItemService.DeleteTask(id))
        return Ok();
      else
        return BadRequest();
    }
  }
}
