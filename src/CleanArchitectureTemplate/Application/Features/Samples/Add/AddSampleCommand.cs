using Application.Contracts.Samples;

namespace Application.Features.Samples.Add;

/// <summary>
/// Adds a new sample. Returns a newly created sample response.
/// </summary>
/// <param name="Data">Sample request data.</param>
public record AddSampleCommand(AddSampleRequest Data) : ICommand<SampleResponse>;
