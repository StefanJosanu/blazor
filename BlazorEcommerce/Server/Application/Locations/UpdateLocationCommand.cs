using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class UpdateLocationCommand : IRequest<LocationManagementDTO>
    {
        public Guid Id { get; set; }
        public LocationManagementDTO updateLocationDTO { get; set; }    
        public UpdateLocationCommand(Guid id, LocationManagementDTO UpdateLocationDTO)
        {
            Id = id;
            updateLocationDTO = UpdateLocationDTO; 
        }
    }
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, LocationManagementDTO>
    {
        private readonly AppDbContext _dbContext;

        public UpdateLocationCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LocationManagementDTO> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var dbLocation = await _dbContext.Locations.Where(l => l.Id == request.Id).FirstOrDefaultAsync();

            if (dbLocation != null)
            {
                dbLocation.Name = request.updateLocationDTO.Name;
                dbLocation.Address = request.updateLocationDTO.Address;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return null;
            }
            return request.updateLocationDTO;
        }
    }
}
