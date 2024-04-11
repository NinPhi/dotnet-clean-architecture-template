using Domain.Modules.Samples;
using Infrastructure.Caching.Constants;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

internal class CachingSampleRepository(
    ISampleRepository sampleRepository, IMemoryCache cache)
    : ISampleRepository
{
    public async Task<List<Sample>> GetAllAsync()
    {
        var samples = await cache.GetOrCreateAsync(
            CacheKeys.AllSamples,
            async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                return await sampleRepository.GetAllAsync();
            });

        return samples ?? [];
    }

    public async Task<List<Sample>> GetAllOfTypeAsync(SampleType type)
    {
        var samples = await cache.GetOrCreateAsync(
            CacheKeys.AllSamplesOfType,
            async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                return await sampleRepository.GetAllOfTypeAsync(type);
            });

        return samples ?? [];
    }

    public Task<Sample?> GetByIdAsync(long id)
    {
        var sample = cache.GetOrCreateAsync(
            CacheKeys.SampleWithId + id,
            cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                return sampleRepository.GetByIdAsync(id);
            });

        return sample;
    }

    public void Add(Sample entity) => sampleRepository.Add(entity);

    public void Update(Sample entity) => sampleRepository.Update(entity);

    public void Remove(Sample entity) => sampleRepository.Remove(entity);
}
