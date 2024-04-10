using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

public interface ISampleRepository : IRepository<Sample>
{
    Task<List<Sample>> GetAllOfTypeAsync(SampleType type);
}