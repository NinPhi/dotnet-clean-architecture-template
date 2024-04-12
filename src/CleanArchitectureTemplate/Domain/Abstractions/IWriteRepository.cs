namespace Domain.Abstractions;

/// <summary>
/// Generic interface representing a write repository for <typeparamref name="TEntity"/>. For writing only.
/// Not meant to be used outside of domain.
/// </summary>
/// <typeparam name="TEntity">Type of entity.</typeparam>
public interface IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Adds the specified entity of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> object.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Updates the specified entity of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> object.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Removes the specified entity of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> object.</param>
    void Remove(TEntity entity);
}
