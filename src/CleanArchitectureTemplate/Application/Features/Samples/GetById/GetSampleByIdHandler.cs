using Application.Contracts.Samples;
using Domain.Modules.Samples;

namespace Application.Features.Samples.GetById;

internal sealed class GetSampleByIdHandler(ISampleRepository sampleRepository)
    : IQueryHandler<GetSampleByIdQuery, SampleResponse>
{
    public async Task<Result<SampleResponse>> Handle(
        GetSampleByIdQuery request, CancellationToken cancellationToken)
    {
        var sample = await sampleRepository.GetByIdAsync(request.Id);

        if (sample is null)
            return Result.Ok<SampleResponse>();

        var response = sample.Adapt<SampleResponse>();

        return response;
    }
}
