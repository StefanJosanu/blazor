using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Data.Entities;
using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Products
{
    public class ReadProductQuerry : IRequest<List<Product>>
    {
    }

    public class ReadProductQuerryHandler : IRequestHandler<ReadProductQuerry, List<Product>>
    {
        private readonly AppDbContext _dbContext;

        public ReadProductQuerryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> Handle(ReadProductQuerry request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
