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

        public async void CreateLocation(LocationManagementDTO locationToAdd)
        {
            await _http.PostAsJsonAsync("api/location/create-locations", locationToAdd);
        }

        public async Task<List<GetLocationDTO>> GetLocations()
        {
            return await _http.GetFromJsonAsync<List<GetLocationDTO>>("api/location/get-locations");
        }
    }
}
