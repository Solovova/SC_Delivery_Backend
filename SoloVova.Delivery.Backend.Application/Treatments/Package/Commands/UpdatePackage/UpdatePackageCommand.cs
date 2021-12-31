using System;
using MediatR;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage{
    public class UpdatePackageCommand: IRequest {
          public Guid Id { get; set; }
          public string Title { get; set; }
          public string Details { get; set; }
    }
}