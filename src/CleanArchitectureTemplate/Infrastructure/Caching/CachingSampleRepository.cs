using Domain.Modules.Samples;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

/// <summary>
/// Caching decorator for the <see cref="ISampleRepository"/> interface.
/// </summary>
/// <param name="sampleRepository"><see cref="ISampleRepository"/> service to be decorated.</param>
/// <param name="cache">Cache service.</param>
internal class CachingSampleRepository(
    ISampleRepository sampleRepository, IMemoryCache cache)
    : ISampleRepository
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public void Add(Sample entity) => sampleRepository.Add(entity);

    /// <inheritdoc/>
    public void Update(Sample entity) => sampleRepository.Update(entity);

    /// <inheritdoc/>
    public void Remove(Sample entity) => sampleRepository.Remove(entity);
}
