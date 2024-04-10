using Application.Contracts.Samples;

namespace Application.Features.Samples.Get;

public record GetSamplesQuery(SampleType? Type) : IQuery<List<SampleResponse>>;