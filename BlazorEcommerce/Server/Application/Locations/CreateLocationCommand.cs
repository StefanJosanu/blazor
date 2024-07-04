using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class CreateLocationCommand : IRequest<Unit>
    {
        public LocationManagementDTO Location { get; set; }
        public CreateLocationCommand(LocationManagementDTO location)
        {
            Location = location;
        }
    }

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public CreateLocationCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToAdd = new Location
            {
                Name = request.Location.Name,
                Address = request.Location.Address
            };
            await _dbContext.Locations.AddAsync(locationToAdd);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
