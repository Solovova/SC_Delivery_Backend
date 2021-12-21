using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Common.Exception;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage{
    public class UpdatePackageCommandHandler{
        private readonly IDeliveryDbContext _dbContext;

        public UpdatePackageCommandHandler(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        public async Task Handle(UpdatePackageCommand request, CancellationToken cancellationToken){
            
            var entity = await _dbContext.Package.FirstOrDefaultAsync(
                note => note.Id == request.Id,
                cancellationToken
            );

            if (entity == null ){
                throw new NotFoundException(nameof(Package), request.Id);
            }

            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}