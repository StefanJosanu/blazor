using MediatR;

namespace BlazorEcommerce.Server;

public class RemoveProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public RemoveProductCommand(Guid id)
    {
        Id = id;
    }
}

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Unit>
{
    private readonly AppDbContext _dbContext;
    public RemoveProductCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _dbContext.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

        if(productToDelete != null)
        {
            _dbContext.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
