using PlannerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerAPI.Repositoties
{
  public interface ITodoItemRepository : IGenericRepository<TodoItem>
  {
    Task<IEnumerable<TodoItem>> GetCurrentTasks();
    Task<IEnumerable<TodoItem>> GetOverdueTasks();
  }
}
