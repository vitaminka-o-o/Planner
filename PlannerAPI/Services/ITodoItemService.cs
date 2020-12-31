using PlannerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerAPI.Services
{
  public interface ITodoItemService
  {
    Task CreateTask(TodoItem item);
    Task<IEnumerable<TodoItem>> GetAllTasks();
    Task<IEnumerable<TodoItem>> GetCurrentTasks();
    Task<IEnumerable<TodoItem>> GetOverdueTasks();
    Task<TodoItem> GetTask(int id);
    Task<bool> UpdateTask(int id, TodoItem item);
    Task<bool> DeleteTask(int id);
  }
}
