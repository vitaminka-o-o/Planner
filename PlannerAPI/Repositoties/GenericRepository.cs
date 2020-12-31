using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerAPI.Repositoties
{
  public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
  {
    private readonly PlannerDBContext _dbContext;

    public GenericRepository(PlannerDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetById(int id) => await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);

    public async Task Create(TEntity entity)
    {
      _dbContext.Set<TEntity>().Add(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Update(int id, TEntity entity)
    {
      var item = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
      if (item != null)
      {
        _dbContext.Entry(item).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();
        return true;
      }
      else
        return false;
    }

      public async Task<bool> Delete(int id)
    {
      var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
      if (entity != null)
      {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
      }
      else
        return false;
    }
  }
}
