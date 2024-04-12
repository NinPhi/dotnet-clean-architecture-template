using Application.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

/// <summary>
/// Caching decorator for the <see cref="IUnitOfWork"/> interface.
/// </summary>
/// <param name="unitOfWork"><see cref="IUnitOfWork"/> service to be decorated.</param>
/// <param name="cache"><see cref="IMemoryCache"/> service.</param>
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
