using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class GetLocationByIdQuerry : IRequest<Location>
    {
        public Guid Id { get; set; }
        public GetLocationByIdQuerry(Guid id)
        {
            Id = id;
        }
    }
    public class GetLocationByIdQuerryHandler : IRequestHandler<GetLocationByIdQuerry, Location>
    {
        private readonly AppDbContext _dbContext;

        public GetLocationByIdQuerryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Location> Handle(GetLocationByIdQuerry request, CancellationToken cancellationToken)
        {
            return await _dbContext.Locations.Where(l => l.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
