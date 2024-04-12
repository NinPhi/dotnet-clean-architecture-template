namespace Domain.Abstractions;

/// <summary>
/// Generic interface representing a write repository. For writing only.
/// Not meant to be used outside of domain.
/// </summary>
/// <typeparam name="TEntity">Type of entity.</typeparam>
public interface IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">Entity object.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">Entity object.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">Entity object.</param>
    void Remove(TEntity entity);
}
