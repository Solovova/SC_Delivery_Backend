using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoloVova.Delivery.Backend.Application.Common.Exception;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.DeletePackage{
    public class DeletePackageCommandHandler: IRequestHandler<DeletePackageCommand>{
        private readonly IDeliveryDbContext _dbContext;

        public DeletePackageCommandHandler(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletePackageCommand request, CancellationToken cancellationToken){
            var entity = await _dbContext.Package.FindAsync(
                new object[]{request.Id},
                cancellationToken
            );

            if (entity == null){
                throw new NotFoundException(nameof(Package), request.Id);
            }

            _dbContext.Package.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}