using Application.Contracts.Samples;
using Domain.Modules.Samples;

namespace Application.Features.Samples.GetMultiple;

public record GetMultipleSamplesQuery(SampleType? Type) : IQuery<List<SampleResponse>>;