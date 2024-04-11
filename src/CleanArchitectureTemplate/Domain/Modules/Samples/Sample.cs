namespace Domain.Modules.Samples;

public class Sample : Entity
{
    [StringLength(500)]
    public required string Text { get; set; }

    public required SampleType Type { get; set; }
}
