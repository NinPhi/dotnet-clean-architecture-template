using Application.Contracts.Samples;
using Application.Features.Samples.Add;
using Application.Features.Samples.GetById;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/samples")]
public class SampleController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation("Gets a sample by ID.")]
    [SwaggerResponse(200,
        Description = "Sample entry.", Type = typeof(SampleResponse))]
    [SwaggerResponse(400, Type = typeof(Result))]
    public async Task<IActionResult> GetById(long id)
    {
        var query = new GetSampleByIdQuery(id);

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
}
