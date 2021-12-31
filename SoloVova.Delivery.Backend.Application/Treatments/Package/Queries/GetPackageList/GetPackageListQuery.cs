using System;
using MediatR;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList{
    public class GetPackageListQuery: IRequest<PackageListVm>{
        public Guid UserId{ get; set; }
    }
}