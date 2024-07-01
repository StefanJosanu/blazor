using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Data.Entities;
using MediatR;

namespace BlazorEcommerce.Server.Application.Products
{
    public class ReadByIdQuerry : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
    public class ReadByIdQuerryHandler : IRequestHandler<ReadByIdQuerry, Product>
    {
        private readonly AppDbContext _dbContext;
        public ReadByIdQuerryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> Handle(ReadByIdQuerry request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
