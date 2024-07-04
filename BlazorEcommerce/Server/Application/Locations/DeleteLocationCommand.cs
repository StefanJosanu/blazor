using MediatR;

namespace BlazorEcommerce.Server.Application.Locations
{
    public class DeleteLocationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DeleteLocationCommand(Guid id)
        {
            Id = id;
        }
    }
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public DeleteLocationCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToDelete = await _dbContext.Locations.Where(l => l.Id == request.Id).FirstOrDefaultAsync();

            if (locationToDelete != null)
            {
                _dbContext.Locations.Remove(locationToDelete);
                await _dbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
