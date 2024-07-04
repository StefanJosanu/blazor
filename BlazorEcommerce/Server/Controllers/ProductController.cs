using BlazorEcommerce.Server.Application.Products;
using BlazorEcommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("get-products")]
    public async Task<List<GetProductDTO>> GetAllProducts()
    {
        return await _mediator.Send(new GetProductsQuerry());
    }
    [HttpGet("get-id-product")]
    public async Task<Product> GetProductById(Guid id)
    {
        return await _mediator.Send(new GetProductByIdQuerry(id) { Id = id });
    }
    [HttpPost("create-product")]
    public async Task<CreateProductDTO> CreateProduct([FromBody] CreateProductDTO createProductDTO)
    {
        return await _mediator.Send(new CreateProductCommand(createProductDTO));
    }
    [HttpPut("update-product")]
    public async Task<CreateProductDTO> UpdateProduct (Guid id, [FromBody] CreateProductDTO productDTO)
    {
        return await _mediator.Send(new UpdateProductCommand(id, productDTO) { Id = id });
    }
    [HttpDelete("delete-product")]
    public async Task<Unit> DeleteProduct(Guid id)
    {
        return await _mediator.Send( new RemoveProductCommand(id) { Id = id} );
    }
}
