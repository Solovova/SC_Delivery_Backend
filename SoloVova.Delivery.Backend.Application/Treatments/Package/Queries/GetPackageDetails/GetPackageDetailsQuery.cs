using System;
using MediatR;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails{
    public class GetPackageDetailsQuery: IRequest<PackageDetailsDto>{
        public Guid Id{ get; set; }
    }
}