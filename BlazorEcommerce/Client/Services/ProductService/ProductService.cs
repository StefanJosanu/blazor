using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task CreateProduct(CreateProductDTO product)
        {
            await _http.PostAsJsonAsync("api/product/create-product", product);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _http.DeleteAsync($"api/product/delete-product/{id}");
        }

        public async Task<List<GetProductDTO>> GetAllProducts()
        {
            var response = await _http.GetFromJsonAsync<List<GetProductDTO>>("api/product/get-products");
            
            return response;
        }

        public Task<GetProductDTO> GetProductId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProduct(Guid id, ProductDTO p)
        {
            await _http.PutAsJsonAsync($"api/product/update-product/{id}", p);
        }
    }
}
