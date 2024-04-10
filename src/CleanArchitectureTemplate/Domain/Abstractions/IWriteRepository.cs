namespace Domain.Abstractions;

public interface IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}
