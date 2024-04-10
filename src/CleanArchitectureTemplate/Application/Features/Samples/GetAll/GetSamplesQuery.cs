using Application.Contracts.Samples;

namespace Application.Features.Samples.GetAll;

public record GetSamplesQuery(SampleType? Type) : IQuery<List<SampleResponse>>;