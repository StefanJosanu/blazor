using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server;

public class GetProductsQuerry : IRequest<List<GetProductDTO>>
{
}

public class GetProductsQuerryHandler : IRequestHandler<GetProductsQuerry, List<GetProductDTO>>
{
    private readonly AppDbContext _dbContext;
    public GetProductsQuerryHandler (AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetProductDTO>> Handle(GetProductsQuerry request, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.Include(p => p.StockLocation).Select(p => new GetProductDTO
        {
            Name = p.Name,
            ShortDescription = p.ShortDescription,
            Description = p.Description,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            StockLocationName = p.StockLocation.Name,
            StockLocationAddress = p.StockLocation.Address
        }).ToListAsync();

    }
}