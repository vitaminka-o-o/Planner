using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannerAPI.Repositoties
{
  public interface IGenericRepository<TEntity>
    where TEntity : class
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(int Id);
    Task Create(TEntity entity);
    Task<bool> Update(int id, TEntity entity);
    Task<bool> Delete(int id);
  }
}
