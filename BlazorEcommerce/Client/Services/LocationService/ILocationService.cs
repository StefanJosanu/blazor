using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.LocationService
{
    public interface ILocationService
    {
        Task<List<LocationManagementDTO>> GetLocations();
        Task CreateLocation(LocationManagementDTO locationToAdd);
        Task UpdateLocation(Guid? id, LocationManagementDTO locationToUpdate);
        Task DeleteLocation(Guid? id);
    }
}
