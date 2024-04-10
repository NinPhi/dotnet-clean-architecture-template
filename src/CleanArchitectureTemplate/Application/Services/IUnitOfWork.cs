namespace Application.Services;

public interface IUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
