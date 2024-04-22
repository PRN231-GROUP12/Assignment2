using System.Linq.Expressions;

namespace PRN231_Group12.Assignment2.Repo.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Remove(int id);
}