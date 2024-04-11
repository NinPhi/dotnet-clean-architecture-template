namespace Domain.Modules.Samples;

public interface ISampleRepository : IRepository<Sample>
{
    Task<List<Sample>> GetAllOfTypeAsync(SampleType type);
}