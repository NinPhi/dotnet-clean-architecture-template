using Domain.Enums;

namespace Application.Contracts.Samples;

public record SampleResponse(long Id, string Text, SampleType Type);