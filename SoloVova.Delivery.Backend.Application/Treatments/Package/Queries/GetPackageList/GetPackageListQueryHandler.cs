using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList{
    public class GetPackageListQueryHandler{
        private readonly IDeliveryDbContext _dbContext;

        public GetPackageListQueryHandler(IDeliveryDbContext dbContext){
            _dbContext = dbContext;
        }
        
        public async Task<PackageListVm> Handle(GetPackageListQuery request,CancellationToken cancellationToken){
            var packageQuery = await _dbContext.Package
                .Where(note => true)
                .ToListAsync(cancellationToken);

            var packageListDto = new List<PackageLookupDto>();
            foreach (var package in packageQuery){
                var packageLookupDto = new PackageLookupDto(){
                    Id = package.Id,
                    Title = package.Title
                };
                packageListDto.Add(packageLookupDto);
            }
            return new PackageListVm{Packages = packageListDto};
        }
    }
}