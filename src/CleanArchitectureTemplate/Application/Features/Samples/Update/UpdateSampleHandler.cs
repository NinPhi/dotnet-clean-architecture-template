
namespace Application.Features.Samples.Update;

internal sealed class UpdateSampleHandler(
    ISampleRepository sampleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateSampleCommand>
{
    public async Task<Result> Handle(
        UpdateSampleCommand request, CancellationToken cancellationToken)
    {
        var sample = await sampleRepository.GetByIdAsync(request.Id);

        if (sample is null)
            return Result.Fail<object>("Specified sample was not found.");

        request.Data.Adapt(sample);

        sampleRepository.Update(sample);

        await unitOfWork.SaveChangesAsync();

        return Result.Ok<object>();
    }
}
