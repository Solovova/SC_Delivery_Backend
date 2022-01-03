using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Common.Exception;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails{
    public class GetPackageDetailsQueryHandler: IRequestHandler<GetPackageDetailsQuery,PackageDetailsDto>{
        private readonly IDeliveryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPackageDetailsQueryHandler(IDeliveryDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<PackageDetailsDto> Handle(GetPackageDetailsQuery request,CancellationToken cancellationToken){
            var entity = await _dbContext.Package.FirstOrDefaultAsync(
                package => package.Id == request.Id,
                cancellationToken
            );

            if (entity == null ){
                throw new NotFoundException(nameof(Package), request.Id);
            }
            
            
            return _mapper.Map<PackageDetailsDto>(entity);
        }
    }
}