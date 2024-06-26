﻿namespace Domain.Abstractions;

/// <summary>
/// Generic interface representing a readonly repository for <typeparamref name="TEntity"/>. For querying only.
/// Not meant to be used outside of domain.
/// </summary>
/// <typeparam name="TEntity">Type of entity.</typeparam>
public interface IReadRepository<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Retrieves all <typeparamref name="TEntity"/> entities.
    /// </summary>
    /// <returns>Task representing an async operation. Returns a list of entities.</returns>
    Task<List<TEntity>> GetAllAsync();

    /// <summary>
    /// Retrieves an entity of the <typeparamref name="TEntity"/> type for the specified identifier.
    /// Returns null if the identifier was not found.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Task representing an async operation. Returns <typeparamref name="TEntity"/> object.</returns>
    Task<TEntity?> GetByIdAsync(long id);
}
