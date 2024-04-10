namespace Domain.Abstractions;

internal interface IReadRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(long id);
}
