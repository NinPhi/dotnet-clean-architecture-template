using Application.Contracts.Samples;
using Application.Features.Samples.Add;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/samples")]
public class SampleController(ISender sender) : ControllerBase
{
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
