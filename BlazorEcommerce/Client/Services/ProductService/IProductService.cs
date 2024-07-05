using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        Task<List<GetProductDTO>> GetAllProducts();
    }
}
