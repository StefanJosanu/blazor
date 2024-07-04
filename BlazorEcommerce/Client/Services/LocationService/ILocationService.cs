using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.LocationService
{
    public interface ILocationService
    {
        Task<List<GetLocationDTO>> GetLocations();
    }
}
