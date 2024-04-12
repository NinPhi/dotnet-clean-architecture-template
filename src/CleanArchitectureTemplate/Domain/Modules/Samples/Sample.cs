namespace Domain.Modules.Samples;

/// <summary>
/// Sample entity for display of a single module in the architecture.
/// </summary>
public class Sample : Entity
{
    /// <summary>
    /// Sample text property with a length constraint.
    /// </summary>
    [StringLength(500)]
    public required string Text { get; set; }

    /// <summary>
    /// Sample enum type property.
    /// </summary>
    public required SampleType Type { get; set; }
}
