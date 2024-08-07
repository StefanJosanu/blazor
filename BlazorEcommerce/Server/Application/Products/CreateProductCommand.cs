﻿using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Products
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public CreateProductDTO Product { get; set; }

        public CreateProductCommand(CreateProductDTO product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandle : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductCommandHandle(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productToAdd = new Product
            {
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
