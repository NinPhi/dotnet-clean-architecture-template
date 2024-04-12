using Domain.Modules.Samples;

namespace Application.Contracts.Samples;

/// <summary>
/// Immutable request record for an operation of updating an existing sample.
/// </summary>
public record UpdateSampleRequest
{
    /// <summary>
    /// Sample text.
    /// </summary>
    [Required]
    [StringLength(500)]
    public string? Text { get; init; }

    /// <summary>
    /// Type of sample.
    /// </summary>
    [Required]
    [EnumDataType(typeof(SampleType))]
    public SampleType Type { get; init; }
}
