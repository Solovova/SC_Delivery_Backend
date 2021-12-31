using System;
using MediatR;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.DeletePackage{
    public class DeletePackageCommand: IRequest{
        public Guid Id{ get; set; }
    }
}