using Application.Contracts.Samples;

namespace Application.Features.Samples.Update;

public record UpdateSampleCommand(long Id, UpdateSampleRequest Data) : ICommand;
