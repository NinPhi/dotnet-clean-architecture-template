using Domain.Modules.Samples;

namespace Application.Contracts.Samples;

/// <summary>
/// Immutable sample response.
/// </summary>
/// <param name="Id">Sample identifier.</param>
/// <param name="Text">Sample text.</param>
/// <param name="Type">Type of sample.</param>
public record SampleResponse(long Id, string Text, SampleType Type);