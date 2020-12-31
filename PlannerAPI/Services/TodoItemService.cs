using PlannerAPI.Models;
using PlannerAPI.Repositoties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerAPI.Services
{
  public class TodoItemService : ITodoItemService
  {
    private ITodoItemRepository _todoItemRepository;
    public TodoItemService(ITodoItemRepository todoItemRepository)
    {
      _todoItemRepository = todoItemRepository;
    }

    public async Task CreateTask(TodoItem item)
    {
      item.Date = DateTime.Now;
      await _todoItemRepository.Create(item);
    }

    public async Task<IEnumerable<TodoItem>> GetAllTasks() => await _todoItemRepository.GetAll();

    public async Task<IEnumerable<TodoItem>> GetCurrentTasks() => await _todoItemRepository.GetCurrentTasks();
    
    public async Task<IEnumerable<TodoItem>> GetOverdueTasks() => await _todoItemRepository.GetOverdueTasks();

    public async Task<TodoItem> GetTask(int id) => await _todoItemRepository.GetById(id);

    public async Task<bool> UpdateTask(int id, TodoItem item) => await _todoItemRepository.Update(id, item);

    public async Task<bool> DeleteTask(int id) => await _todoItemRepository.Delete(id);
    
  }
}
