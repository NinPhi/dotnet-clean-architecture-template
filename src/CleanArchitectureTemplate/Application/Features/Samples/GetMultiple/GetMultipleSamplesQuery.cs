using Application.Contracts.Samples;

namespace Application.Features.Samples.GetMultiple;

public record GetMultipleSamplesQuery(SampleType? Type) : IQuery<List<SampleResponse>>;