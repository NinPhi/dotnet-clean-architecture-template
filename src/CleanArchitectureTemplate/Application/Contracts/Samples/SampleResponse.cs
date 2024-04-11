using Domain.Modules.Samples;

namespace Application.Contracts.Samples;

public record SampleResponse(long Id, string Text, SampleType Type);