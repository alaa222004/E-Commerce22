


namespace E_Commerce.Persistence.Repositories;

internal class UnitOfWork(ApplicationDBContext dBContext) : IUnitOfWork
{
    private readonly Dictionary<string, object> _repositories = [];
    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        if (_repositories.ContainsKey(typeName))
           return (IRepository<TEntity, TKey>)_repositories[typeName]!;
        var repo = new Repository<TEntity, TKey>(dBContext);
        _repositories.Add(typeName, repo);
        return repo;
    }
       
    
       
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await dBContext.SaveChangesAsync(cancellationToken);

}
