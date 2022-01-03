using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList{
    public class GetPackageListQueryHandler: IRequestHandler<GetPackageListQuery,PackageListVm>{
        private readonly IDeliveryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPackageListQueryHandler(IDeliveryDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<PackageListVm> Handle(GetPackageListQuery request,CancellationToken cancellationToken){
            var packageQuery = await _dbContext.Package
                .Where(note => true)
                .ToListAsync(cancellationToken);

            var packageListDto = new List<PackageListRecordDto>();
            foreach (var package in packageQuery){
                packageListDto.Add(_mapper.Map<PackageListRecordDto>(package));
            }
            return new PackageListVm{Packages = packageListDto};
        }
    }
}