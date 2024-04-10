using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Samples;

public record AddSampleRequest
{
    [Required]
    [StringLength(500)]
    public string? Text { get; init; }

    [Required]
    [EnumDataType(typeof(SampleType))]
    public SampleType Type { get; init; }
}
