using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Data.Entities;
using BlazorEcommerce.Shared;
using MediatR;
using System.Runtime.InteropServices;

namespace BlazorEcommerce.Server.Application.Products
{
    public class CreateProductCommand: IRequest<ProductDTO>
    {
        public ProductDTO Product { get; set; }
        public CreateProductCommand(ProductDTO product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductCommandHandler(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productToAdd = new Product
            {
                Name = request.Product.Name,
                Description = request.Product.Description,
                ShortDescription = request.Product.ShortDescription,
                Price = request.Product.Price,
                StockQuantity = request.Product.StockQuantity
            };
            
            await _dbContext.Products.AddAsync(productToAdd);
            await _dbContext.SaveChangesAsync();

            request.Product.Id = productToAdd.Id;
            return request.Product;
        }
    }
}
