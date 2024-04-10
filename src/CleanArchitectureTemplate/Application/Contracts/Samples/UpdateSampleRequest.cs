namespace Application.Contracts.Samples;

public record UpdateSampleRequest
{
    [Required]
    [StringLength(500)]
    public string? Text { get; init; }

    [Required]
    [EnumDataType(typeof(SampleType))]
    public SampleType Type { get; init; }
}
