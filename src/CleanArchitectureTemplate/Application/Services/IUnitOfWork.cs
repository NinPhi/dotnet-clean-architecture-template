namespace Application.Services;

/// <summary>
/// Interface representing a single atomic unit of work.
/// Should be used for feature operations to take effect.
/// </summary>
public interface IUnitOfWork
{
    int SaveChanges();

    Task<int> SaveChangesAsync();
}
