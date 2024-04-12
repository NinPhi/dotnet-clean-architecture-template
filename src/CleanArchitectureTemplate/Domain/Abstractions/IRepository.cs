namespace Domain.Abstractions;

/// <summary>
/// Generic interface representing a read-write repository for type <typeparamref name="TEntity"/>.
/// Not meant to be used outside of domain.
/// </summary>
/// <typeparam name="TEntity">Type of entity.</typeparam>
public interface IRepository<TEntity>
    : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : class, IEntity;
