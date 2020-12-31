using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Repositoties
{
  public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
  {
    private readonly PlannerDBContext _dbContext;

    public TodoItemRepository(PlannerDBContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<TodoItem>> GetOverdueTasks()
    {
      return await _dbContext.Set<TodoItem>().Where(x => x.IsCompleted == false && x.Date < DateTime.Today).ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetCurrentTasks()
    {
      return await _dbContext.Set<TodoItem>().Where(x => x.Date > DateTime.Today).ToListAsync();
    }
  }
}
