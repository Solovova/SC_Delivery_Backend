using System;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails{
    public class PackageDetailsDto{
        public Guid Id{ get; set; }
        public string? Title{ get; set; }
        public string? Details{ get; set; }
    }
}