using System;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage{
    public class CreatePackageCommand {
          public Guid IdCreateUser{ get; set; }
          public string Title { get; set; }
          public string Details { get; set; }
    }
}