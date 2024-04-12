namespace Application.Features.Samples.Delete;

/// <summary>
/// Deletes an existing sample by identifier.
/// </summary>
/// <param name="Id">Sample identifier.</param>
public record DeleteSampleCommand(long Id) : ICommand;