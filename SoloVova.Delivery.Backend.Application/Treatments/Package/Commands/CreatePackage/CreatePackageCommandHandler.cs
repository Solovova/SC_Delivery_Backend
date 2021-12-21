using System;
using System.Threading;
using System.Threading.Tasks;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage{
    public class CreatePackageCommandHandler{
        private readonly IDeliveryDbContext _dbContext;

        public CreatePackageCommandHandler(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        public async Task<Guid> Handle(CreatePackageCommand request, CancellationToken cancellationToken){
            var package = new Domain.Package{
                IdCreateUser = request.IdCreateUser,
                IdDeliveryman = Guid.Empty,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,
                
                CreationDate = DateTime.Now,
                EditDate = null,
                AddressFrom = null
            };

            await _dbContext.Package.AddAsync(package, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return package.Id;
        }
    }
}