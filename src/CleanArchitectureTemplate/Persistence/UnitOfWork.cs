using Application.Services;

namespace Persistence;

/// <summary>
/// Implementation of <see cref="IUnitOfWork"/> interface.
/// </summary>
/// <param name="dbContext"><see cref="AppDbContext"/> service.</param>
internal class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public int SaveChanges() => dbContext.SaveChanges();

    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}
