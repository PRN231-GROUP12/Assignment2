using PRN231_Group12.Assignment2.Repo.Interfaces;

namespace PRN231_Group12.Assignment2.Repo.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookPublishingDBContext _dbContext;

    public UnitOfWork(BookPublishingDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IRepository<TEntity> GetRequiredRepository<TEntity>() where TEntity : class
        => new Repository<TEntity>(_dbContext);

    public async Task<int> CommitAsync()
        => await _dbContext.SaveChangesAsync();
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}