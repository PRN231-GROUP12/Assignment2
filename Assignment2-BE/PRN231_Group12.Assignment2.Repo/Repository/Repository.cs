using System.Linq.Expressions;
using PRN231_Group12.Assignment2.Repo.Interfaces;

namespace PRN231_Group12.Assignment2.Repo.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly BookPublishingDBContext _dbContext;

    public Repository(BookPublishingDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> GetAll() => _dbContext.Set<TEntity>();

    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        => _dbContext.Set<TEntity>().Where(predicate);

    public async Task<TEntity?> GetByIdAsync(int id)
        => await _dbContext.Set<TEntity>().FindAsync(id);

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity);
        return entityEntry.Entity;
    }

    public TEntity Update(TEntity entity)
    {
        var entityEntry = _dbContext.Set<TEntity>().Update(entity);
        return entityEntry.Entity;
    }

    public TEntity Remove(int id)
    {
        var entity = GetByIdAsync(id).Result;
        var entityEntry = _dbContext.Set<TEntity>().Remove(entity!);
        return entityEntry.Entity;
    }
}