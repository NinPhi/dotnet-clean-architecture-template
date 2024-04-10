using Application.Contracts.Samples;

namespace Application.Features.Samples.GetAll;

internal sealed class GetSamplesHandler(ISampleRepository sampleRepository)
    : IQueryHandler<GetSamplesQuery, List<SampleResponse>>
{
    public async Task<Result<List<SampleResponse>>> Handle(
        GetSamplesQuery request, CancellationToken cancellationToken)
    {
        List<Sample> samples;

        if (request.Type.HasValue)
        {
            samples = await sampleRepository.GetAllOfTypeAsync(request.Type.Value);
        }
        else
        {
            samples = await sampleRepository.GetAllAsync();
        }

        var response = samples.Adapt<List<SampleResponse>>();

        return response;
    }
}
