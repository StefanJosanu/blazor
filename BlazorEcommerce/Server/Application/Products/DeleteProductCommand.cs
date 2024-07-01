using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Data.Entities;
using MediatR;

namespace BlazorEcommerce.Server.Application.Products
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly AppDbContext _dbContext;
        public DeleteProductCommandHandler(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _dbContext.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
            _dbContext.Products.Remove(productToDelete);

            _dbContext.SaveChangesAsync();
            return productToDelete;
        }
    }
}
