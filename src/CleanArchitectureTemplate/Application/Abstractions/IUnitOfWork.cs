namespace Application.Abstractions;

public interface IUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
