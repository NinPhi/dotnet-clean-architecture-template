namespace Domain.Abstractions;

/// <summary>
/// Generic interface representing a readonly repository. For querying only.
/// Not meant to be used outside of domain.
/// </summary>
/// <typeparam name="TEntity">Type of entity.</typeparam>
public interface IReadRepository<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Retrieves all entities of the type.
    /// </summary>
    /// <returns>Task representing an async operation. Returns a list of entities.</returns>
    Task<List<TEntity>> GetAllAsync();

    /// <summary>
    /// Retrieves an entity of the type for the specified identifier.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Task representing an async operation. Returns an entity.</returns>
    Task<TEntity?> GetByIdAsync(long id);
}
