namespace Domain.Modules.Samples;

/// <summary>
/// Sample repository interface.
/// Serves as a contract to define what actions can be done on the sample entity.
/// </summary>
public interface ISampleRepository : IRepository<Sample>
{
    /// <summary>
    /// Gets all samples of the specified type.
    /// </summary>
    /// <param name="type">Sample type for filtering.</param>
    /// <returns>Task representing an async operation. Returns a filtered list of samples.</returns>
    Task<List<Sample>> GetAllOfTypeAsync(SampleType type);
}