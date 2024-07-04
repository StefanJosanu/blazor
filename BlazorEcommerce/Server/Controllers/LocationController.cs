using BlazorEcommerce.Server.Application.Locations;
using BlazorEcommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server;
[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;
    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("get-locations")]
    public async Task<List<Location>> GetLocations()
    {
        return await _mediator.Send(new GetLocationsQuerry());
    }
    [HttpGet("get-id-location")]
    public async Task<Location> GetLocationById(Guid id)
    {
        return await _mediator.Send(new GetLocationByIdQuerry(id) { Id = id });
    }
    [HttpPost("create-locations")]
    public async Task<UpdateLocationDTO> CreateLocation([FromBody] UpdateLocationDTO locationDTO)
    {
        return await _mediator.Send(new CreateLocationCommand(locationDTO));
    }
    [HttpPut("update-location")]
    public async Task<UpdateLocationDTO> UpdateLocation(Guid id, [FromBody] UpdateLocationDTO updateLocation)
    {
        return await _mediator.Send(new UpdateLocationCommand(id, updateLocation) { Id = id });
    }
    [HttpDelete("delete-location")]
    public async Task<Unit> DeleteLocation(Guid id)
    {
        return await _mediator.Send(new DeleteLocationCommand(id) { Id = id });
    }
}
