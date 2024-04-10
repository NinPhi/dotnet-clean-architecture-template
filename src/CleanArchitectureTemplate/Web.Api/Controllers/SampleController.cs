using Application.Contracts.Samples;
using Application.Features.Samples.Add;
using Application.Features.Samples.Delete;
using Application.Features.Samples.GetMultiple;
using Application.Features.Samples.GetById;
using Application.Features.Samples.Update;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/samples")]
public class SampleController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation("Gets a sample by ID.")]
    [SwaggerResponse(200,
        Description = "Sample entry.", Type = typeof(SampleResponse))]
    [SwaggerResponse(204, Description = "Sample was not found.")]
    [SwaggerResponse(400, Type = typeof(Result))]
    public async Task<IActionResult> GetById(long id)
    {
        var query = new GetSampleByIdQuery(id);

        var result = await sender.Send(query);

        if (result.IsError)
            return BadRequest(result);

        return Ok(result.Value);
    }

    [HttpGet]
    [SwaggerOperation(
        "Gets all available samples.",
        "If sample type is specified, samples are filtered by the type.")]
    [SwaggerResponse(200,
        Description = "Sample entries.", Type = typeof(List<SampleResponse>))]
    [SwaggerResponse(400, Type = typeof(Result))]
    public async Task<IActionResult> Get(SampleType? type = null)
    {
        var query = new GetMultipleSamplesQuery(type);

        var result = await sender.Send(query);

        if (result.IsError)
            return BadRequest(result);

        return Ok(result.Value);
    }

    [HttpPost]
    [SwaggerOperation("Adds a new sample.")]
    [SwaggerResponse(200,
        Description = "Added sample entry.", Type = typeof(SampleResponse))]
    [SwaggerResponse(400, Type = typeof(Result))]
    public async Task<IActionResult> Add(AddSampleRequest request)
    {
        var command = new AddSampleCommand(request);

        var result = await sender.Send(command);

        if (result.IsError)
            return BadRequest(result);

        return Created($"api/samples/{result.Value!.Id}", result.Value);
    }

    [HttpPut("{id}")]
    [SwaggerOperation("Updates an existing sample.")]
    [SwaggerResponse(204, Description = "Sample was updated successfully.")]
    [SwaggerResponse(400, Type = typeof(Result))]
    public async Task<IActionResult> Update(long id, UpdateSampleRequest request)
    {
        var command = new UpdateSampleCommand(id, request);

        var result = await sender.Send(command);

        if (result.IsError)
            return BadRequest(result);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Deletes an existing sample.")]
    [SwaggerResponse(204, Description = "Sample was deleted successfully or wasn't found.")]
    [SwaggerResponse(400, Type = typeof(Result))]
    public async Task<IActionResult> Delete(long id)
    {
        var command = new DeleteSampleCommand(id);

        var result = await sender.Send(command);

        if (result.IsError)
            return BadRequest(result);

        return NoContent();
    }
}
