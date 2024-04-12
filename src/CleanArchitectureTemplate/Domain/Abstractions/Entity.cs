namespace Domain.Abstractions;

/// <summary>
/// Base abstract class representing an entity.
/// </summary>
public abstract class Entity : IEntity
{
    /// <summary>
    /// Entity identifier.
    /// </summary>
    public long Id { get; set; }
}
