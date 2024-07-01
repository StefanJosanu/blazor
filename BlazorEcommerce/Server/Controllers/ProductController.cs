using BlazorEcommerce.Server.Application.Products;
using BlazorEcommerce.Server.Data.Entities;
using BlazorEcommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpGet("products")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _mediator.Send(new ReadProductQuerry());
        }
        [HttpGet("productId")]
        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _mediator.Send(new ReadByIdQuerry() { Id = id });
            return product;
        }
        [HttpPost("add")]
        public async Task<ProductDTO> CreateProduct([FromBody] ProductDTO product) 
        {
            return await _mediator.Send(new CreateProductCommand(product));
        }
        [HttpPut("update-product")]
        public async Task<ProductDTO> UpdateProduct([FromBody] ProductDTO product, Guid productId)
        {
            return await _mediator.Send(new UpdateProductCommand(productId, product) { Id = productId });
        }
        [HttpDelete("id")]
        public async Task<Product> DeleteProduct(Guid id)
        {
            return await _mediator.Send(new DeleteProductCommand() { Id = id });
        }
    }
}
