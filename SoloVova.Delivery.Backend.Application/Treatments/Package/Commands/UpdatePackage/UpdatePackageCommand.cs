using System;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage{
    public class UpdatePackageCommand {
          public Guid Id { get; set; }
          public string Title { get; set; }
          public string Details { get; set; }
    }
}