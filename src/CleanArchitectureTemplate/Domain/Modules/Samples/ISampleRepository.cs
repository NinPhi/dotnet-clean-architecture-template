namespace Domain.Modules.Samples;

/// <summary>
/// <see cref="Sample"/> repository interface.
/// Serves as a contract to define what actions can be done on the entity.
/// </summary>
public interface ISampleRepository : IRepository<Sample>
{
    /// <summary>
    /// Retrieves all <see cref="Sample"/> entities of the <paramref name="type"/>.
    /// </summary>
    /// <param name="type"><see cref="SampleType"/> for filtering.</param>
    /// <returns>Task representing an async operation. Returns a filtered list of samples.</returns>
    Task<List<Sample>> GetAllOfTypeAsync(SampleType type);
}