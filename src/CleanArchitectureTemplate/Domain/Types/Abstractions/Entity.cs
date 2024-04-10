namespace Domain.Types.Abstractions;

public abstract class Entity : IEntity
{
    public long Id { get; set; }
}
