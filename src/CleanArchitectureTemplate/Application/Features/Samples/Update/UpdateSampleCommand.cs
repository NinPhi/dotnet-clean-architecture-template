using Application.Contracts.Samples;

namespace Application.Features.Samples.Update;

/// <summary>
/// Updates a sample by identifier.
/// </summary>
/// <param name="Id">Sample identifier.</param>
/// <param name="Data">Updated sample data.</param>
public record UpdateSampleCommand(long Id, UpdateSampleRequest Data) : ICommand;
