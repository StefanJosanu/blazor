using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class GetLocationsQuery : IRequest<List<GetLocationDTO>>
    {

    }

    public class GetLocationsQuerryHandle : IRequestHandler<GetLocationsQuery, List<GetLocationDTO>>
    {
        private readonly AppDbContext _dbContext;

        public GetLocationsQuerryHandle(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetLocationDTO>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Locations.Select(l => new GetLocationDTO
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address
            })
            .OrderBy(l => l.Name)
            .ToListAsync();
        }
    }
}
