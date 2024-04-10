using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class SampleRepository(AppDbContext dbContext) : ISampleRepository
{
    public Task<List<Sample>> GetAllAsync() =>
        dbContext.Samples.AsNoTracking().ToListAsync();

    public Task<List<Sample>> GetAllOfTypeAsync(SampleType type) =>
        dbContext.Samples
            .AsNoTracking()
            .Where(s => s.Type == type)
            .ToListAsync();

    public Task<Sample?> GetByIdAsync(long id) =>
        dbContext.Samples.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

    public void Add(Sample entity) =>
        dbContext.Samples.Add(entity);

    public void Update(Sample entity) =>
        dbContext.Samples.Update(entity);

    public void Remove(Sample entity) =>
        dbContext.Samples.Remove(entity);
}
