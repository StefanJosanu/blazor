using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Products
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }
        public ProductDTO Product { get; set; }

        public UpdateProductCommand(Guid id, ProductDTO product)
        {
            Product = product;
            id = Id;
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly AppDbContext _dbContext;
        public UpdateProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var dbProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id ==  request.Id);

            dbProduct.Name = request.Product.Name;
            dbProduct.ShortDescription = request.Product.ShortDescription;
            dbProduct.Description = request.Product.Description;
            dbProduct.Price = request.Product.Price;
            dbProduct.StockQuantity = request.Product.StockQuantity;

            await _dbContext.SaveChangesAsync();
            return request.Product;
        }
    }
}
