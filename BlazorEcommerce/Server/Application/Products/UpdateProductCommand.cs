using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server;

public class UpdateProductCommand : IRequest<CreateProductDTO>
{
    public Guid Id { get; set; }
    public CreateProductDTO productDTO { get; set; }

    public UpdateProductCommand(Guid id, CreateProductDTO ProductDTO)
    {
        Id = id;
        productDTO = ProductDTO;
    }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CreateProductDTO>
{
    private readonly AppDbContext _dbContext;

    public UpdateProductCommandHandler (AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var dbProduct = await _dbContext.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

        if (dbProduct != null)
        {
            dbProduct.Name = request.productDTO.Name;
            dbProduct.ShortDescription = request.productDTO.ShortDescription;
            dbProduct.Description = request.productDTO.Description;
            dbProduct.StockQuantity = request.productDTO.StockQuantity;
            dbProduct.Price = request.productDTO.Price;
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            return null;
        }
        return request.productDTO;
    }
}
