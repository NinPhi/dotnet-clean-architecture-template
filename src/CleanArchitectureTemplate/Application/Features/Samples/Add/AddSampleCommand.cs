using Application.Contracts.Samples;

namespace Application.Features.Samples.Add;

public record AddSampleCommand(AddSampleRequest Data) : ICommand<SampleResponse>;
