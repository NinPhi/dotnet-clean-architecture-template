
using Application.Services;
using Domain.Modules.Samples;

namespace Application.Features.Samples.Delete;

internal sealed class DeleteSampleHandler(
    ISampleRepository sampleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteSampleCommand>
{
    public async Task<Result> Handle(
        DeleteSampleCommand request, CancellationToken cancellationToken)
    {
        var sample = await sampleRepository.GetByIdAsync(request.Id);

        if (sample is null)
            return Result.Ok<object>();

        sampleRepository.Remove(sample);

        await unitOfWork.SaveChangesAsync();

        return Result.Ok<object>();
    }
}
