using Domain.Modules.Samples;

namespace Application.Contracts.Samples;

/// <summary>
/// Immutable request record for an operation of adding a new sample.
/// </summary>
public record AddSampleRequest
{
    /// <summary>
    /// Sample text.
    /// </summary>
    [Required]
    [StringLength(500)]
    public string? Text { get; init; }

    /// <summary>
    /// Type of the sample.
    /// </summary>
    [Required]
    [EnumDataType(typeof(SampleType))]
    public SampleType Type { get; init; }
}
