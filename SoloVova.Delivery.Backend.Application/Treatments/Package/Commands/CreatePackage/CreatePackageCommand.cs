using System;
using MediatR;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage{
    public class CreatePackageCommand: IRequest<Guid> {
          public Guid IdCreateUser{ get; set; }
          public string Title { get; set; }
          public string Details { get; set; }
    }
}