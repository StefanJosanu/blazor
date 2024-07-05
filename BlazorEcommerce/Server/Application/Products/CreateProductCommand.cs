﻿using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Products
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public ProductDTO Product { get; set; }

        public CreateProductCommand(ProductDTO product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productToAdd = new Product
            {
                Id = request.Product.Id,
                Name = request.Product.Name,
                ShortDescription = request.Product.ShortDescription,
                Description = request.Product.Description,
                Price = request.Product.Price,
                StockQuantity = request.Product.StockQuantity,
                StockLocationId = request.Product.StockLocationId
            };
            await _dbContext.Products.AddAsync(productToAdd);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
