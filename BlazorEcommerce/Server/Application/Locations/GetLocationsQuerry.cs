using MediatR;

namespace BlazorEcommerce.Server;

public class GetLocationsQuerry : IRequest<List<Location>>
{

}

public class GetLocationsQuerryHandler : IRequestHandler<GetLocationsQuerry, List<Location>>
{
    private readonly AppDbContext _dbContext;

    public GetLocationsQuerryHandler (AppDbContext dbContext)
    {
        _dbContext = dbContext;    
    }
    public async Task<List<Location>> Handle(GetLocationsQuerry request, CancellationToken cancellationToken)
    {
        return await _dbContext.Locations.ToListAsync();
    }
}