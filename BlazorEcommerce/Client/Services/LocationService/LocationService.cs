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

        public async Task<List<LocationDTO>> GetLocations()
        {
            return await _http.GetFromJsonAsync<List<LocationDTO>>("api/location/get-locations");
        }

        public async Task UpdateLocation(LocationManagementDTO locationToUpdate)
        {
            await _http.PutAsJsonAsync("api/location/update-location", locationToUpdate);
        }
    }
}
