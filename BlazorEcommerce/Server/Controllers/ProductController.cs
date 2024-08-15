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
        return await _mediator.Send(new GetProductByIdQuerry(id) { Id = new Guid() });
    }

    [HttpPost("create-product")]
    public async Task<Unit> CreateProduct([FromBody] CreateProductDTO createProductDTO)
    {
        return await _mediator.Send(new CreateProductCommand(createProductDTO));
    }

    [HttpPut("update-product/{id}")]
    public async Task<ProductDTO> UpdateProduct (Guid id, [FromBody] ProductDTO productDTOs)
    {
        return await _mediator.Send(new UpdateProductCommand() { Id = id, productDTO = productDTOs});
    }

    [HttpDelete("delete-product/{id}")]
    public async Task<Unit> DeleteProduct(Guid id)
    {
        return await _mediator.Send( new RemoveProductCommand(id));
    }
}
