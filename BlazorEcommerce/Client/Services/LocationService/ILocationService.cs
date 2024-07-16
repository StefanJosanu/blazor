using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.LocationService
{
    public interface ILocationService
    {
        Task<List<LocationDTO>> GetLocations();
        Task CreateLocation(LocationManagementDTO locationToAdd);
    }
}
