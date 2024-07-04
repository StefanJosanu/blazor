using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class GetLocationByIdQuery : IRequest<GetLocationDTO>
    {
        public Guid Id { get; set; }
        public GetLocationDTO Location = new GetLocationDTO();
        public GetLocationByIdQuery(Guid id)
        {
            Id = id;
        }
    }


    public class GetLocationByIdQuerryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationDTO>
    {
        private readonly AppDbContext _dbContext;

        public GetLocationByIdQuerryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetLocationDTO> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var dbLocation = await _dbContext.Locations.FindAsync(request.Id);

            if(dbLocation != null)
            {
                request.Location.Id = dbLocation.Id;
                request.Location.Name = dbLocation.Name;
                request.Location.Address = dbLocation.Address;
            }

            return request.Location;
        }
    }


}
