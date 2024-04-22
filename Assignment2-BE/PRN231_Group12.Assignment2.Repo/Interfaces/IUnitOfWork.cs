namespace PRN231_Group12.Assignment2.Repo.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRequiredRepository<TEntity>() where TEntity : class;
    Task<int> CommitAsync();
}