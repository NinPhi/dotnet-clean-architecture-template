using Application.Contracts.Samples;

namespace Application.Features.Samples.Add;

internal sealed class AddSampleHandler(
    ISampleRepository sampleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddSampleCommand, SampleResponse>
{
    public async Task<Result<SampleResponse>> Handle(
        AddSampleCommand request, CancellationToken cancellationToken)
    {
        var sample = request.Data.Adapt<Sample>();

        sampleRepository.Add(sample);

        await unitOfWork.SaveChangesAsync();

        var response = sample.Adapt<SampleResponse>();

        return response;
    }
}
