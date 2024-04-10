namespace Domain.Abstractions;

public interface IReadRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(long id);
}
