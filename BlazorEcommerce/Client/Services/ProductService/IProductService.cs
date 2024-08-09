using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        Task<List<GetProductDTO>> GetAllProducts();
        Task<GetProductDTO> GetProductId(Guid id);
        Task CreateProduct(CreateProductDTO product);
        Task DeleteProduct(Guid id);
        Task UpdateProduct(Guid id, ProductDTO product);
    }
}
