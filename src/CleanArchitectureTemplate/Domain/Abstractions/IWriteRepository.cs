namespace Domain.Abstractions;

internal interface IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
