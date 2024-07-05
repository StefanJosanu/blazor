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
    public async Task<List<GetLocationDTO>> GetLocations()
    {
        return await _mediator.Send(new GetLocationsQuery());
    }

    [HttpGet("get-id-location")]
    public async Task<GetLocationDTO> GetLocationById(Guid id)
    {
        return await _mediator.Send(new GetLocationByIdQuery(id) { Id = id });
    }

    [HttpPost("create-locations")]
    public async Task<Unit> CreateLocation([FromBody] LocationManagementDTO locationDTO)
    {
        return await _mediator.Send(new CreateLocationCommand(locationDTO));
    }

    [HttpPut("update-location")]
    public async Task<LocationManagementDTO> UpdateLocation(Guid id, [FromBody] LocationManagementDTO updateLocation)
    {
        return await _mediator.Send(new UpdateLocationCommand(id, updateLocation) { Id = id });
    }

    [HttpDelete("delete-location")]
    public async Task<Unit> DeleteLocation(Guid id)
    {
        return await _mediator.Send(new DeleteLocationCommand(id) { Id = id });
    }

}
