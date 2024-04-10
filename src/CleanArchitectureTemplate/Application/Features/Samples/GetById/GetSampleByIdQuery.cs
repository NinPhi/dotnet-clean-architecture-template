using Application.Contracts.Samples;

namespace Application.Features.Samples.GetById;

public record GetSampleByIdQuery(long Id) : IQuery<SampleResponse>;