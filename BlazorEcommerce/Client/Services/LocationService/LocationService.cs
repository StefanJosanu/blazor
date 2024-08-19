using BlazorEcommerce.Shared;
using MediatR;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _http;
        
        public LocationService(HttpClient http)
        {
            _http = http;
        }

        public async Task CreateLocation(LocationManagementDTO locationToAdd)
        {
            await _http.PostAsJsonAsync("api/location/create-locations", locationToAdd);
        }

        public async Task DeleteLocation(Guid? id)
        {
            await _http.DeleteAsync($"api/location/delete-location/{id}");
        }

        public async Task<List<LocationManagementDTO>> GetLocations()
        {
            return await _http.GetFromJsonAsync<List<LocationManagementDTO>>("api/location/get-locations");
        }

        public async Task UpdateLocation(Guid? id,LocationManagementDTO locationToUpdate)
        {
            await _http.PutAsJsonAsync($"api/location/update-location/{id}", locationToUpdate);
        }
    }
}
