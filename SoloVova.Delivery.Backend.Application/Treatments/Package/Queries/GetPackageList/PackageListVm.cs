using System.Collections.Generic;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList{
    public class PackageListVm{
        public IList<PackageListRecordDto>? Packages{ get; set; }
    }
}