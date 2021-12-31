using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Common.Exception;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage{
    public class UpdatePackageCommandHandler: IRequestHandler<UpdatePackageCommand>{
        private readonly IDeliveryDbContext _dbContext;

        public UpdatePackageCommandHandler(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(UpdatePackageCommand request, CancellationToken cancellationToken){
            
            var entity = await _dbContext.Package.FirstOrDefaultAsync(
                package => package.Id == request.Id,
                cancellationToken
            );

            if (entity == null ){
                throw new NotFoundException(nameof(Package), request.Id);
            }

            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}