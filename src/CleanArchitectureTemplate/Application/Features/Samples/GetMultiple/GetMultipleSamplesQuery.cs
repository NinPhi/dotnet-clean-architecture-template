using Application.Contracts.Samples;
using Domain.Modules.Samples;

namespace Application.Features.Samples.GetMultiple;

/// <summary>
/// Retrieves multiple samples. Returns a list of samples filtered by type.
/// If not type is specified, returns all available samples.
/// </summary>
/// <param name="Type">Type of samples.</param>
public record GetMultipleSamplesQuery(SampleType? Type) : IQuery<List<SampleResponse>>;