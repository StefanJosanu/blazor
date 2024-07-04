using BlazorEcommerce.Shared;
using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class UpdateLocationCommand : IRequest<UpdateLocationDTO>
    {
        public Guid Id { get; set; }
        public UpdateLocationDTO updateLocationDTO { get; set; }    
        public UpdateLocationCommand(Guid id, UpdateLocationDTO UpdateLocationDTO)
        {
            Id = id;
            updateLocationDTO = UpdateLocationDTO; 
        }
    }
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationDTO>
    {
        private readonly AppDbContext _dbContext;

        public UpdateLocationCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdateLocationDTO> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
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
