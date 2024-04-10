using Application.Abstractions;

namespace Persistence;

internal class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public int SaveChanges() => dbContext.SaveChanges();

    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}
