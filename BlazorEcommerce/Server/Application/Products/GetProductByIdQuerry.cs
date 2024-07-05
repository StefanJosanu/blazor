using MediatR;

namespace BlazorEcommerce.Server;

public class GetProductByIdQuerry : IRequest<Product>
{
    public Guid Id { get; set; }
    public GetProductByIdQuerry(Guid id)
    {
        Id = id;
    }
}

public class GetProductByIdQuerryHandler : IRequestHandler<GetProductByIdQuerry, Product>
{
    private readonly AppDbContext _dbContext;

    public GetProductByIdQuerryHandler (AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product> Handle(GetProductByIdQuerry request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
        if(product != null)
        {
            return product;
        }
        return null;
    }
}
