using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Common.Exception;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails{
    public class GetPackageDetailsQueryHandler{
        private readonly IDeliveryDbContext _dbContext;

        public GetPackageDetailsQueryHandler(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        public async Task<PackageDetailsDto> Handle(GetPackageDetailsQuery request,CancellationToken cancellationToken){
            var entity = await _dbContext.Package.FirstOrDefaultAsync(
                package => package.Id == request.Id,
                cancellationToken
            );

            if (entity == null ){
                throw new NotFoundException(nameof(Package), request.Id);
            }
            
            return new PackageDetailsDto(){
                Id = entity.Id,
                Title = entity.Title,
                Details = entity.Details
            };
        }
    }
}