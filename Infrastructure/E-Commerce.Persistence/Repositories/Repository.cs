


global using E_Commerce.Domain.Entities;

namespace E_Commerce.Persistence.Repositories;

public class Repository<TEntity, TKey>(ApplicationDBContext dBContext) : IRepository<TEntity, TKey>where TEntity : Entity<TKey>
{
    public void Add(TEntity entity)
   => dBContext.Set<TEntity>().Add(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    
=> await dBContext.Set<TEntity>().ToListAsync(cancellationToken);


    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
   => await dBContext.Set<TEntity>().FindAsync(id, cancellationToken);



    public void Remove(TEntity entity)
   => dBContext.Set<TEntity>().Remove(entity);
    public void Update(TEntity entity)
    => dBContext.Set<TEntity>().Update(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)

=> await dBContext.Set<TEntity>().ApplySpecification(specification).ToListAsync(cancellationToken);

    public async Task<TEntity?> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await dBContext.Set<TEntity>()
            .ApplySpecification(specification)
            .FirstOrDefaultAsync(cancellationToken);
    }




}
