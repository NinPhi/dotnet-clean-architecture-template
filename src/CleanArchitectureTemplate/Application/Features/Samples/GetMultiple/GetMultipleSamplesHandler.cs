using Application.Contracts.Samples;
using Domain.Modules.Samples;

namespace Application.Features.Samples.GetMultiple;

internal sealed class GetMultipleSamplesHandler(ISampleRepository sampleRepository)
    : IQueryHandler<GetMultipleSamplesQuery, List<SampleResponse>>
{
    public async Task<Result<List<SampleResponse>>> Handle(
        GetMultipleSamplesQuery request, CancellationToken cancellationToken)
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
