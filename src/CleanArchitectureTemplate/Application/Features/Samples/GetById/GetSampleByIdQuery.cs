using Application.Contracts.Samples;

namespace Application.Features.Samples.GetById;

/// <summary>
/// Retrieves a single sample by identifier. Returns a sample response.
/// </summary>
/// <param name="Id">Sample identifier.</param>
public record GetSampleByIdQuery(long Id) : IQuery<SampleResponse>;