using Application.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

internal class CachingUnitOfWork(IUnitOfWork unitOfWork, IMemoryCache cache) : IUnitOfWork
{
    public int SaveChanges()
    {
        if (cache is MemoryCache memoryCache) memoryCache.Clear();

        return unitOfWork.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        if (cache is MemoryCache memoryCache) memoryCache.Clear();
        
        return unitOfWork.SaveChangesAsync();
    }
}
