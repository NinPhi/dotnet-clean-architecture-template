using Domain.Modules.Samples;

namespace Persistence.Repositories;

/// <summary>
/// Concrete <see cref="ISampleRepository"/> implementation class.
/// </summary>
/// <param name="dbContext"><see cref="AppDbContext"/> service.</param>
internal sealed class SampleRepository(AppDbContext dbContext) : ISampleRepository
{
    /// <inheritdoc/>
    public Task<List<Sample>> GetAllAsync() =>
        dbContext.Samples.AsNoTracking().ToListAsync();

    /// <inheritdoc/>
    public Task<List<Sample>> GetAllOfTypeAsync(SampleType type) =>
        dbContext.Samples
            .AsNoTracking()
            .Where(s => s.Type == type)
            .ToListAsync();

    /// <inheritdoc/>
    public Task<Sample?> GetByIdAsync(long id) =>
        dbContext.Samples.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

    /// <inheritdoc/>
    public void Add(Sample entity) =>
        dbContext.Samples.Add(entity);

    /// <inheritdoc/>
    public void Update(Sample entity) =>
        dbContext.Samples.Update(entity);

    /// <inheritdoc/>
    public void Remove(Sample entity) =>
        dbContext.Samples.Remove(entity);
}
